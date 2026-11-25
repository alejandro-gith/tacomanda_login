# Alcance y fuentes

Las once historias están implementadas. Las reglas y las rutas añadidas se describen en [ALCANCE_COMPLETO.md](ALCANCE_COMPLETO.md).

| Tarjeta | Estado en esta entrega |
|---|---|
| 01 Inicio de sesión | Implementada con nombres exactos. |
| 02 Crear comanda | Implementada con nombres exactos. |
| 03 Alta de empleados | Implementada; mesero y cajero. |
| 04 Crear platillo | Implementada. |
| 05 Editar platillo | Implementada. |
| 06 Consultar platillo | Implementada; catálogo para mesero y administrador. |
| 07 Eliminar platillo | Implementada como baja lógica. |
| 08 Consultar comanda | Implementada; lista y detalle. |
| 09 Cambiar estado | Implementada en cocina. |
| 10 Cobrar comanda | Implementada como registro local simulado. |
| 11 Editar comanda | Implementada para comandas pendientes del mesero. |

## Diferencia entre las dos tarjetas de cobro recibidas

El PDF general usa CobrarComandaMeseroComponent / CobrarComandaMeseroViewModel / CobrarComandaMeseroFacade, IPagoRepository y DetalleComanda.
El PDF específico más reciente usa **MeseroPage, CobrarComandaViewModel, MeseroFacade, IPedidoRepository y DetalleDeComanda**.
También asigna a IMesaRepository la liberación de mesa y a TacomandaDbContext la transacción del cobro.
Para el cobro se siguió la nomenclatura del PDF general y se registró un pago simulado; no se conecta a ninguna pasarela bancaria. Las interfaces de escritura y lectura se mantienen separadas cuando un consumidor solo necesita lectura.

## Nombres que ya no se usan

OrdersController, CreateOrderCommand, LoginCommand, WaiterFacade y ApiService genérico no forman parte de esta entrega.
Sus equivalentes son ComandasController, CrearComandaCommand, IniciarSesionCommand, CrearComandaFacade y clientes HTTP especializados.

Los servicios técnicos añadidos figuran en MAPA_CRC e INVENTARIO_ARCHIVOS. Se distinguen de las clases que aparecen literalmente en los PDF.

## Adaptación posterior solicitada

La versión vigente utiliza MediatR para despachar Commands y Queries, con un ValidationBehavior que llama a los validators antes de los handlers. AutoMapper realiza las conversiones a DTO. Los readers de las consultas delegan en repositorios; CrearComandaHandler utiliza IMeseroRepository directamente. Los nombres de las tarjetas se mantienen y la infraestructura técnica adicional se documenta por separado.
