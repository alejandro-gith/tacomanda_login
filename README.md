# TacoManda · Angular + ASP.NET Core + MySQL

Sistema para Tacos Angy. Incluye las historias US01–US19: selección de mesa, catálogo, captura y edición de comanda, administración de platillos y empleados, autenticación y roles, consulta y cambio de estado en cocina, cobro, ticket y adaptación a pantallas pequeñas. También incluye cierre de caja y retroalimentación, que aparecen en el esquema entregado.

## Estructura

| Carpeta | Responsabilidad |
|---|---|
| `frontend` | Angular: Component, ViewModel, Facade y API Client por pantalla. |
| `backend/src/Tacomanda.Api` | Controllers y contratos HTTP; llama a MediatR y responde HTTP. |
| `backend/src/Tacomanda.Application` | Commands, Queries, Validators y Handlers; orquesta casos de uso. |
| `backend/src/Tacomanda.Domain` | Entidades, invariantes y contratos pequeños de repositorios. |
| `backend/src/Tacomanda.Infrastructure` | EF Core, MySQL, repositorios, JWT y hash de contraseñas. |
| `database/schema.sql` | Tablas, relaciones y datos iniciales de referencia. **Borra la base `tacomanda` existente.** |
| `docs` | Mapa de flujos, inventario y guía de base de datos. |

Las lecturas usan Query → QueryHandler → Reader → Repository → MySQL. Las escrituras usan Command → ValidationBehavior → Validator → Handler → Repository → MySQL. Las entidades protegen las reglas de negocio. Las contraseñas se guardan con PBKDF2 y los IDs del empleado autenticado provienen del JWT, no del JSON enviado por Angular.

## Requisitos

- MySQL 8 o posterior con acceso local en el puerto 3306.
- SDK .NET 10 y Node.js 24.
- MySQL CLI para importar `database/schema.sql`.

## Instalación local (PowerShell)

1. Importa la base con el cliente de MySQL:

   ```powershell
   mysql -u root -p
   ```

   Dentro de la consola de MySQL ejecuta `SOURCE E:/ruta/a/Tacomanda-final-mysql/database/schema.sql;` usando la ruta real. **Esto elimina cualquier base previa llamada `tacomanda`.** La importación crea cinco mesas, ocho platillos, productos y relaciones de ingredientes.

2. Copia el ejemplo de configuración local (el archivo real se ignora en Git):

   ```powershell
   Copy-Item backend/src/Tacomanda.Api/appsettings.Development.example.json backend/src/Tacomanda.Api/appsettings.Development.json
   ```

3. Abre `backend/src/Tacomanda.Api/appsettings.Development.json` y sustituye
   `CAMBIA_POR_TU_CLAVE_MYSQL` por la contraseña local de MySQL. Si MySQL
   está en otro equipo o usa otro usuario, cambia también `Server`, `Port` y
   `User`. El archivo `.example.json` es solo una plantilla: la API carga el
   archivo **sin** `.example` al usar el perfil Development. La contraseña
   queda en el archivo local excluido de Git; no la copies al frontend.

4. Ejecuta el backend desde `backend`:

   ```powershell
   dotnet restore Tacomanda.sln
   dotnet build Tacomanda.sln
   dotnet run --project src/Tacomanda.Api
   ```

5. En otra terminal, desde `frontend`:

   ```powershell
   npm ci
   npm start
   ```

Abre `http://localhost:4200` (también se admite `http://127.0.0.1:4200` en desarrollo). La API escucha en `http://localhost:8080`. El primer inicio de la API en **Development** crea las cuentas `admin/admin123`, `mesero/mesero123`, `cajero/cajero123` y `cocina/cocina123` si no hay empleados; únicamente son cuentas de demostración. Cambia las contraseñas antes de usar otros entornos.

Al abrir el login, Angular consulta `GET /api/auth/users` contra la API, que lee
los empleados activos de MySQL. Si la consulta falla o tarda más de 15 segundos,
la pantalla deja de cargar, muestra el mensaje general y permite reintentar.
Seleccionar una cuenta en la lista no consulta la base; `POST /api/auth/login`
se envía únicamente al pulsar **ENTRAR AL PUESTO**. Revisa la consola del
navegador y la de la API para diagnosticar un error sin exponerlo en pantalla.

En otros sistemas, quien instala el servidor configura `ConnectionStrings:Tacomanda` y `Jwt:Key` (32 bytes o más) en un gestor de secretos o en la configuración protegida del servicio; el cliente final no usa la terminal. En el primer arranque de una base sin empleados, configura también `BootstrapAdmin:Username` y `BootstrapAdmin:Password` (8–128 caracteres): se crea un administrador con contraseña hasheada. Después puede dar de alta meseros, cajeros y cocina. El frontend de producción usa `/api`, por lo que debe existir un proxy o servidor que dirija esa ruta a ASP.NET Core. No distribuyas `appsettings.Development.json` con contraseñas reales ni lo publiques en GitHub.

## Uso rápido por rol

| Rol | Ruta inicial | Acciones |
|---|---|---|
| Mesero | `/comandas/crear` | Capturar/editar comanda pendiente, consultar sus comandas, cobrar las suyas listas, imprimir ticket. |
| Cocinero | `/cocina` | Ver comandas y pasar de `Pendiente` a `EnPreparacion` y después a `Lista`. |
| Cajero | `/caja` | Consultar comandas listas, cobrar, reimprimir ticket y registrar cierre de caja. |
| Administrador | `/administracion` | Crear/editar/desactivar platillos, alta de meseros, cajeros y cocina, cierre de caja. |

Cada rol puede enviar retroalimentación. Para cambiar de turno se cierra la sesión y el siguiente empleado selecciona su cuenta y escribe su propia contraseña. El pago con tarjeta **solo se registra**: no existe conexión con una terminal bancaria ni un cargo real. La impresión usa el diálogo del navegador y depende de la impresora instalada.

## Códigos y datos

Los controllers deciden 200, 201 o 204 al responder; las reglas y la validación permanecen en Application y Domain. Entrada incorrecta: 400; credenciales inválidas: 401; rol no autorizado: 403; recurso inexistente: 404; regla o concurrencia: 409; fallo inesperado: 500. La respuesta de error contiene `Error en el sistema.` y `traceId`; el detalle técnico se registra en consola.

La base persiste los cambios entre reinicios. Los precios y el total se calculan en el servidor; `detalle_comanda` conserva nombre y precio de venta históricos. El cierre de caja suma **ventas en efectivo** desde el último cierre y registra la diferencia con el efectivo contado. `productos` y `platillo_producto` almacenan las relaciones de ingredientes proporcionadas; el esquema no define existencias ni un flujo de inventario.

### Folio diario, propina y ticket

Cada comanda conserva su `id_comanda` interno y recibe `fecha_operativa` y `numero_diario` visibles. El número comienza en 1 cada fecha de **America/Mexico_City** y se asigna transaccionalmente al crear la comanda. El cierre de caja no reinicia el número. Se muestra la fecha junto al número porque el #1 vuelve a existir al día siguiente.

En el cobro se puede elegir **sin propina** o 15%, 18%, 20% o 25%; el servidor acepta cualquier porcentaje de 15% a 100% con hasta dos decimales si más adelante se amplía la UI. El porcentaje se calcula sobre el consumo y se redondea a centavos. El ticket muestra consumo, propina, total a cobrar, monto recibido y cambio; el resumen de efectivo incluye las propinas cobradas en efectivo. La propina no modifica precios históricos de los platillos.

Para nuevas instalaciones use `database/schema.sql` solo en una base vacía. Si ya hay datos, haga un respaldo y ejecute **una vez** `database/upgrade_propinas_y_folios.sql` con la API detenida; nunca vuelva a ejecutar `schema.sql` sobre esa base. Reinicie la API con la nueva versión tras actualizar el esquema.

El ticket ofrece formato **58 mm** (predeterminado) y **80 mm**. Elija también el ancho real del rollo en el diálogo o controlador de impresión; el botón usa el navegador del equipo que abre el ticket, no Render. Pruebe con una impresión real antes de usarlo en caja.

Para recorrer cada archivo: [MAPA_CRC.md](docs/MAPA_CRC.md), [FLUJO.md](docs/FLUJO.md), [INVENTARIO_ARCHIVOS.md](docs/INVENTARIO_ARCHIVOS.md), [INTEGRACION_MYSQL.md](docs/INTEGRACION_MYSQL.md).

## Verificación

```powershell
node scripts/verificar-arquitectura.mjs
node scripts/verificar-api.mjs
```

El segundo script requiere la API arrancada con cuentas demo y por lo menos dos mesas libres; crea comandas y cobros reales. No se ejecuta automáticamente al iniciar el proyecto. Consulta [VERIFICACION.md](docs/VERIFICACION.md) para resultados y límites de prueba.
