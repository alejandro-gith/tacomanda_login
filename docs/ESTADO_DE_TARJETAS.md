# Alcance y fuentes

Se conserva el alcance parcial acordado: login y crear comanda, con lecturas de apoyo. No se entregan archivos vacíos que aparenten implementar los demás casos.

| Tarjeta | Estado en esta entrega |
|---|---|
| 01 Inicio de sesión | Implementada con nombres exactos. |
| 02 Crear comanda | Implementada con nombres exactos. |
| 03 Alta de empleados | Fuera del alcance parcial. |
| 04 Crear platillo | Fuera del alcance parcial. |
| 05 Editar platillo | Fuera del alcance parcial. |
| 06 Consultar platillo | Backend y API Client reutilizados para capturar comanda; no pantalla independiente. |
| 07 Eliminar platillo | Fuera del alcance parcial. |
| 08 Consultar comanda | Fuera del alcance parcial. |
| 09 Cambiar estado | Fuera del alcance parcial. |
| 10 Cobrar comanda | Fuera del alcance parcial; ambas fuentes incluidas para trazabilidad. |
| 11 Editar comanda | Fuera del alcance parcial. |

## Diferencia entre las dos tarjetas de cobro recibidas

El PDF general usa CobrarComandaMeseroComponent / CobrarComandaMeseroViewModel / CobrarComandaMeseroFacade, IPagoRepository y DetalleComanda.
El PDF específico más reciente usa **MeseroPage, CobrarComandaViewModel, MeseroFacade, IPedidoRepository y DetalleDeComanda**.
También asigna a IMesaRepository la liberación de mesa y a TacomandaDbContext la transacción del cobro.
No se fusionaron esas definiciones incompatibles ni se implementó cobro por inferencia.

Cuando se amplíe al cobro, el PDF específico podrá ser su referencia sin modificar las responsabilidades de los archivos de login y creación. Las interfaces de escritura y lectura deberán seguir siendo pequeñas; un mismo nombre de tarjeta usado en varios casos no obliga a cada consumidor a depender de todas sus operaciones.

## Nombres que ya no se usan

OrdersController, CreateOrderCommand, LoginCommand, WaiterFacade y ApiService genérico no forman parte de esta entrega.
Sus equivalentes son ComandasController, CrearComandaCommand, IniciarSesionCommand, CrearComandaFacade y clientes HTTP especializados.

Los servicios técnicos añadidos figuran en MAPA_CRC e INVENTARIO_ARCHIVOS. Se distinguen de las clases que aparecen literalmente en los PDF.

## Adaptación posterior solicitada

La versión vigente utiliza MediatR para despachar Commands y Queries, con un ValidationBehavior que llama a los validators antes de los handlers. AutoMapper realiza las conversiones a DTO. Los readers de las consultas delegan en repositorios; CrearComandaHandler utiliza IMeseroRepository directamente. Los nombres de las tarjetas se mantienen y la infraestructura técnica adicional se documenta por separado.
