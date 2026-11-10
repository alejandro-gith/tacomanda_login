# Verificación de esta entrega

Se comprobó el proyecto refactorizado, no el ZIP anterior.

## Compilación

- Backend: .NET SDK 10.0.403, compilación de los cuatro proyectos correcta, cero advertencias y cero errores.
- Comando usado en el entorno: `dotnet build Tacomanda.sln -m:1 -nr:false -p:UseSharedCompilation=false`.
- Frontend: `npm run build` correcto, incluidas plantillas Angular y TypeScript estricto.
- Dependencias del frontend: package-lock.json conservado de la entrega anterior.
- Las dependencias SQLite y EF Core se actualizaron durante la comprobación para resolver la alerta NuGet encontrada en la versión inicial.

## API real: 23 comprobaciones correctas

1. Petición sin JWT → 401.
2. JWT inválido → 401.
3. Usuario vacío → 400.
4. Contraseña demasiado corta → 400.
5. Contraseña incorrecta → 401.
6. Usuario inexistente → 401.
7. Login correcto → 200 y sesión.
8. Consulta de mesas → 200.
9. Consulta de platillos → 200.
10. Paginación inválida → 400.
11. Cantidad inválida → 400.
12. Observación excesiva → 400.
13. Detalle de platillo duplicado → 400.
14. Comanda sin detalles → 400.
15. Detalles nulos en el contrato → 400.
16. Mesa inexistente → 404.
17. Platillo inexistente → 409.
18. Creación correcta → 201.
19. Identidad, precio y total: los valores enviados por el cliente no sustituyen la identidad JWT ni el precio del catálogo.
20. Creación sobre mesa ocupada → 409; la mesa figura ocupada al consultarla.
21. Login del cajero → 200.
22. Cajero intenta crear comanda → 403.
23. Dos peticiones simultáneas sobre una mesa → una creación 201 y un conflicto 409.

En las respuestas de error se comprobó el mensaje genérico y la existencia de traceId.
El script reproducible está en `scripts/verificar-api.mjs`; requiere una API recién iniciada y usa únicamente los datos de prueba.

## Inspección de estructura

- Controllers sin lectura de User/Claims, sin Guid.Parse, sin repositorios, sin validadores ni reglas condicionales.
- Commands y queries transportan datos y declaran su respuesta mediante IRequest<T>; MediatR los despacha con ISender.
- ValidationBehavior ejecuta IValidator<T> antes de llamar al handler; AutoMapper convierte entidades a DTOs.
- Sin funciones anónimas en el código fuente propio C#/TypeScript.
- Nombres de las tarjetas 01/02 usados en clases y archivos.
- Base de datos en memoria con transacción real para la comanda y la ocupación de mesa.

No se realizó una prueba visual automatizada en navegador. Los estilos provienen de las pantallas entregadas anteriormente.

## Verificación estructural reproducible

`node scripts/verificar-arquitectura.mjs` comprueba: controllers con ISender y sin reglas/claims; pipeline valida antes del handler; CrearComandaHandler depende de IMeseroRepository directamente; consultas y guardados limitados a Repositories. Los readers de consulta y el seeder no usan el contexto directamente.
