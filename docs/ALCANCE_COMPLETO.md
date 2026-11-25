# Alcance implementado

| Historias | Función |
|---|---|
| US01–US06 y US11 | Selección de mesa, catálogo, carrito con cantidades y observaciones, alta de comanda y total calculado en el servidor. |
| US07–US10 | Crear, consultar, editar y desactivar platillos; precios mayores que cero. |
| US12–US13 y US16 | Inicio con cuenta seleccionada y contraseña, JWT, permisos por rol y cambio de turno con cierre de sesión. |
| US14–US15 | Consulta de comandas activas e historial con detalles. |
| US17 | Cobro en efectivo o registro simulado de tarjeta; mesero de su propia comanda y cajero de las listas. |
| US18 | Ticket consultable e imprimible después del cobro, sin duplicar el pago. |
| US19 | Estilos adaptativos para las pantallas de administración, mesero, caja y cocina. |
| Extensión cocina | `Pendiente → EnPreparacion → Lista`, solo para el rol Cocinero. |
| Extensión del esquema | Cierre de caja con diferencias y retroalimentación 1–5; tablas de productos e ingredientes importadas. |

MediatR y `ValidationBehavior` ejecutan validaciones sintácticas antes del handler. Los handlers coordinan repositorios; las entidades protegen cantidades, importes y transiciones. El controller recibe contratos HTTP, envía Commands/Queries y devuelve el resultado; no abre conexiones ni decide reglas de negocio. Los errores devuelven un mensaje genérico y se registran con `traceId` en consola.

El módulo de inventario no está definido: `productos` y `platillo_producto` representan ingredientes por platillo, pero no contienen stock ni movimientos. La integración bancaria y la impresión física se prueban en el entorno del establecimiento.
