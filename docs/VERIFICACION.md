# Verificación de la entrega MySQL

- `dotnet build Tacomanda.sln`: cuatro proyectos, cero errores y advertencias. En este contenedor se usó `-p:SkipGetTargetFrameworkProperties=true -m:1` para evitar un fallo de evaluación de MSBuild del entorno.
- `npm run build`: Angular y plantillas compiladas con éxito.
- `node scripts/verificar-arquitectura.mjs`: pasó; controllers sin reglas ni consultas SQL, lectores delegan en repositorios, validators en el pipeline MediatR.
- Se inicializó el modelo de EF Core en ejecución con el proveedor MySQL (sin conectar a un servidor): se verificaron las tablas `empleados`, `mesas`, `platillos`, `comandas`, `detalle_comanda`, `pedidos`, `encuestas_cierre` y `retroalimentacion_app`.

**Límite:** no había servidor MySQL ni impresora en el entorno de construcción. Por ello no se ejecutó `scripts/verificar-api.mjs` contra esta nueva base, ni una prueba de impresión física o medición de 1.5 segundos. El script contiene pruebas de login, validación, autorización, creación concurrente, transición cocina, cobro de cajero y relectura del ticket; ejecútalo después de importar `database/schema.sql` con dos mesas libres.

La base es persistente: el script de verificación crea datos y se debe restaurar una base de prueba antes de repetirlo con las mismas condiciones iniciales. No confundas este resultado de compilación y validación del modelo con una prueba integrada de MySQL.
