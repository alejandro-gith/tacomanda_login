# Integración del esquema MySQL

La base se crea con `database/schema.sql`. El script tiene `DROP DATABASE IF EXISTS tacomanda` y por ello **elimina los datos existentes**. Para una base ya usada se necesita una migración que conserve datos, no volver a ejecutar este archivo.

Para una base existente: respalde MySQL/TiDB, detenga la API, ejecute una sola vez `database/upgrade_propinas_y_folios.sql` y reinicie la API actualizada. El script asigna folios históricos por fecha local de Ciudad de México y agrega el contador diario. No lo ejecute dos veces. Para una instalación nueva, `schema.sql` ya incluye las columnas y el contador.

## Ajustes frente al borrador recibido

| Tabla | Ajuste | Motivo |
|---|---|---|
| `empleados` | `usuario` único y `activo`; rol `cocina` | Login por cuenta, permisos y pantalla de cocina. `no_control` sigue siendo la PK entera. |
| `mesas`, `comandas` | `version` | Control optimista de concurrencia; una mesa solo admite una comanda activa. |
| `comandas` | `forma_pago`, `monto_pagado`, `fecha_cobro` | Consultar y reimprimir el ticket después del pago. |
| `detalle_comanda` | `nombre`, `precio_unitario`; `nota` de 200 | Conservar el precio/nombre vendidos aunque el catálogo cambie; soportar observaciones del formulario. |
| `pedidos` | `monto`, `no_control` | Registrar importe recibido y empleado que cobró. `cambio` y `tipo_pedido` se conservan. |
| `platillos` | Longitudes y precio validados también en Application/Domain | Evitar fallas SQL por entrada fuera del esquema. |

Las demás tablas, relaciones y los datos iniciales provienen del esquema recibido. Los IDs públicos son números (`INT`), iguales a sus claves `AUTO_INCREMENT`, sin una capa paralela de GUIDs. Las tablas de ingredientes son datos de referencia; no se modeló control de inventario, ya que no hay cantidades de existencias ni una historia de usuario para hacerlo.

## Seguridad y operación

La API lee `ConnectionStrings:Tacomanda` mediante `GetConnectionString("Tacomanda")`. En Development, copia `appsettings.Development.example.json` a `appsettings.Development.json` y cambia `CAMBIA_POR_TU_CLAVE_MYSQL` por la clave local. El archivo real se ignora en Git; el `.example` no se carga al arrancar. Si la base está en otra máquina, ajusta también servidor, puerto y usuario. `database/schema.sql` crea tablas y datos iniciales, pero no configura la conexión de la API. En Production, el instalador configura la cadena y `Jwt:Key` (al menos 32 bytes) mediante la configuración protegida del servicio. Si no hay empleados, configura `BootstrapAdmin:Username` y `BootstrapAdmin:Password`; el primer administrador se crea con contraseña hasheada y después puede dar de alta los demás roles. No uses la contraseña de MySQL en el frontend ni distribuyas un archivo local con credenciales reales.

El proveedor es `MySql.EntityFrameworkCore` 10.0.12 para EF Core 10. EF solo consulta y escribe desde implementaciones de repositorios; el esquema se importa manualmente y la API no ejecuta `EnsureCreated` ni borra tablas al arrancar. Las operaciones que cambian comanda, pago y mesa comparten un `DbContext` de petición y se confirman con `IUnidadDeTrabajo`.

## Comprobación manual

1. Importa el esquema y arranca API/Angular.
2. Entra como `mesero`, elige una mesa y envía una comanda con un platillo.
3. Entra como `cocina` y pásala a preparación y lista.
4. Entra como `cajero`, cobra y abre `/ticket/<id>`; verifica monto y cambio.
5. Reinicia la API: la comanda y el ticket deben persistir.
6. Registra un cierre de caja y confirma que el resumen siguiente vuelve a cero para pagos en efectivo anteriores al cierre.

La pantalla de ticket usa impresión del navegador; el cargo con tarjeta es simulado. El objetivo de rendimiento e impresión de US18 requiere un equipo y una impresora reales.
