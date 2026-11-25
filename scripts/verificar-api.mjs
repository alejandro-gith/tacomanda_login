import assert from "node:assert/strict";

const baseUrl = process.env.TACOMANDA_API_URL ?? "http://localhost:8080/api";
let verificaciones = 0;

async function solicitar(ruta, method = "GET", body = undefined, token = undefined) {
  const headers = { "Content-Type": "application/json" };
  if (token !== undefined) {
    headers.Authorization = "Bearer " + token;
  }
  const response = await fetch(baseUrl + ruta, {
    method,
    headers,
    body: body === undefined ? undefined : JSON.stringify(body)
  });
  return { status: response.status, data: await response.json() };
}

function comprobar(nombre, respuesta, status) {
  assert.equal(respuesta.status, status, nombre + ": HTTP inesperado");
  if (status >= 400) {
    assert.equal(respuesta.data.message, "Error en el sistema.", nombre);
    assert.ok(respuesta.data.traceId, nombre + ": falta trazabilidad");
  }
  verificaciones++;
  console.log("OK:", nombre);
}

async function ejecutar() {
  comprobar("Sin JWT", await solicitar("/mesas"), 401);
  comprobar("JWT inválido", await solicitar("/mesas", "GET", undefined, "invalido"), 401);
  comprobar("Usuario vacío", await solicitar("/auth/login", "POST", {
    usuario: "", password: "mesero123"
  }), 400);
  comprobar("Contraseña demasiado corta", await solicitar("/auth/login", "POST", {
    usuario: "mesero", password: "123"
  }), 400);
  comprobar("Contraseña incorrecta", await solicitar("/auth/login", "POST", {
    usuario: "mesero", password: "incorrecta123"
  }), 401);
  comprobar("Usuario inexistente", await solicitar("/auth/login", "POST", {
    usuario: "nadie", password: "mesero123"
  }), 401);

  const usuarios = await solicitar("/auth/users");
  comprobar("Usuarios disponibles para el turno", usuarios, 200);
  assert.ok(usuarios.data.some(usuario => usuario.usuario === "mesero"));
  assert.ok(!JSON.stringify(usuarios.data).includes("contrasena"));

  const login = await solicitar("/auth/login", "POST", {
    usuario: "mesero", password: "mesero123"
  });
  comprobar("Inicio de sesión", login, 200);
  const token = login.data.accessToken;
  const mesas = await solicitar("/mesas", "GET", undefined, token);
  const platillos = await solicitar("/platillos", "GET", undefined, token);
  comprobar("Consultar mesas", mesas, 200);
  comprobar("Consultar platillos", platillos, 200);
  comprobar("Paginación inválida", await solicitar("/platillos?pagina=0", "GET", undefined, token), 400);
  const libres = [];
  for (const mesa of mesas.data) {
    if (mesa.disponible) {
      libres.push(mesa);
    }
  }
  assert.ok(libres.length >= 2, "Reinicia la API antes de ejecutar esta comprobación.");
  const mesa = libres[0];
  const platillo = platillos.data[0];
  const detalle = { platilloId: platillo.id, cantidad: 2, observaciones: "Sin cebolla" };

  comprobar("Cantidad inválida", await solicitar("/comandas", "POST", {
    mesaId: mesa.id, detalles: [{ ...detalle, cantidad: 0 }]
  }, token), 400);
  comprobar("Observación excesiva", await solicitar("/comandas", "POST", {
    mesaId: mesa.id, detalles: [{ ...detalle, observaciones: "x".repeat(201) }]
  }, token), 400);
  comprobar("Platillo duplicado", await solicitar("/comandas", "POST", {
    mesaId: mesa.id, detalles: [detalle, detalle]
  }, token), 400);
  comprobar("Sin detalles", await solicitar("/comandas", "POST", {
    mesaId: mesa.id, detalles: []
  }, token), 400);
  comprobar("Contrato con detalles nulos", await solicitar("/comandas", "POST", {
    mesaId: mesa.id, detalles: null
  }, token), 400);
  comprobar("Mesa inexistente", await solicitar("/comandas", "POST", {
    mesaId: 999999999, detalles: [detalle]
  }, token), 404);
  comprobar("Platillo inexistente", await solicitar("/comandas", "POST", {
    mesaId: mesa.id,
    detalles: [{ ...detalle, platilloId: 999999999 }]
  }, token), 409);

  const creada = await solicitar("/comandas", "POST", {
    mesaId: mesa.id,
    meseroId: 999999999,
    total: 0.01,
    detalles: [{ ...detalle, precioUnitario: 0.01 }]
  }, token);
  comprobar("Crear comanda", creada, 201);
  assert.equal(creada.data.meseroId, login.data.empleadoId, "El JSON no debe cambiar al mesero.");
  assert.equal(creada.data.total, platillo.precio * 2, "El precio debe proceder del catálogo.");
  assert.equal(creada.data.detalles[0].observaciones, "Sin cebolla");
  assert.ok(creada.data.numeroDiario >= 1, "La comanda debe tener folio diario.");
  assert.match(creada.data.fechaOperativa, /^\d{4}-\d{2}-\d{2}$/);
  console.log("OK: identidad, precio y total proceden del servidor.");
  verificaciones++;

  comprobar("Mesa ocupada", await solicitar("/comandas", "POST", {
    mesaId: mesa.id, detalles: [detalle]
  }, token), 409);
  const despues = await solicitar("/mesas", "GET", undefined, token);
  for (const actual of despues.data) {
    if (actual.id === mesa.id) {
      assert.equal(actual.disponible, false);
    }
  }
  const cajero = await solicitar("/auth/login", "POST", { usuario: "cajero", password: "cajero123" });
  comprobar("Autenticar cajero", cajero, 200);
  comprobar("Rol sin permiso de crear", await solicitar("/comandas", "POST", {
    mesaId: libres[1].id, detalles: [detalle]
  }, cajero.data.accessToken), 403);

  const cocina = await solicitar("/auth/login", "POST", { usuario: "cocina", password: "cocina123" });
  comprobar("Autenticar cocina", cocina, 200);
  comprobar("Iniciar preparación", await solicitar(`/comandas/${creada.data.id}/estado`, "PATCH",
    { estado: "EnPreparacion" }, cocina.data.accessToken), 200);
  comprobar("Marcar lista", await solicitar(`/comandas/${creada.data.id}/estado`, "PATCH",
    { estado: "Lista" }, cocina.data.accessToken), 200);
  comprobar("Propina inferior al mínimo", await solicitar(`/comandas/${creada.data.id}/cobro`, "POST",
    { formaPago: "Efectivo", monto: creada.data.total + 50, porcentajePropina: 10 },
    cajero.data.accessToken), 400);
  const propina = Math.round(Math.round(creada.data.total * 100) * 15 / 100) / 100;
  const recibido = Math.round((creada.data.total + propina + 50) * 100) / 100;
  const cobrada = await solicitar(`/comandas/${creada.data.id}/cobro`, "POST",
    { formaPago: "Efectivo", monto: recibido, porcentajePropina: 15 }, cajero.data.accessToken);
  comprobar("Cajero cobra y libera mesa", cobrada, 200);
  assert.equal(cobrada.data.estado, "Cobrada");
  assert.equal(cobrada.data.propina, propina);
  assert.equal(cobrada.data.totalConPropina, creada.data.total + propina);
  comprobar("No se puede cobrar dos veces", await solicitar(`/comandas/${creada.data.id}/cobro`, "POST",
    { formaPago: "Efectivo", monto: recibido, porcentajePropina: 15 }, cajero.data.accessToken), 409);
  const ticket = await solicitar(`/comandas/${creada.data.id}`, "GET", undefined, cajero.data.accessToken);
  comprobar("Consultar datos para reimprimir ticket", ticket, 200);
  assert.equal(ticket.data.montoPagado, recibido);
  assert.equal(ticket.data.numeroDiario, creada.data.numeroDiario);
  const resumenCaja = await solicitar("/cierre-caja/resumen", "GET", undefined, cajero.data.accessToken);
  comprobar("Resumen de efectivo", resumenCaja, 200);
  assert.ok(resumenCaja.data.totalSistema >= creada.data.total + propina);
  const cierreCaja = await solicitar("/cierre-caja", "POST", {
    totalContado: resumenCaja.data.totalSistema, huboIncidencias: false, comentarios: "Cierre de prueba"
  }, cajero.data.accessToken);
  comprobar("Registrar cierre", cierreCaja, 200);
  assert.equal(cierreCaja.data.diferencia, 0);
  const opinion = await solicitar("/retroalimentacion", "POST",
    { calificacion: 5, comentario: "Prueba" }, token);
  comprobar("Registrar retroalimentación", opinion, 200);

  const simultaneas = await Promise.all([
    solicitar("/comandas", "POST", { mesaId: libres[1].id, detalles: [detalle] }, token),
    solicitar("/comandas", "POST", { mesaId: libres[1].id, detalles: [detalle] }, token)
  ]);
  const estados = [simultaneas[0].status, simultaneas[1].status].sort();
  assert.deepEqual(estados, [201, 409], "Solo una petición debe ocupar la mesa.");
  const nueva = simultaneas.find(respuesta => respuesta.status === 201).data;
  if (nueva.fechaOperativa === creada.data.fechaOperativa) {
    assert.equal(nueva.numeroDiario, creada.data.numeroDiario + 1,
      "Un conflicto de mesa no debe consumir un folio diario.");
  }
  verificaciones++;
  console.log("OK: concurrencia, una creación y un conflicto.");
  console.log("Comprobaciones completadas:", verificaciones);
}

function registrarFallo(error) {
  console.error(error);
  process.exitCode = 1;
}

ejecutar().catch(registrarFallo);
