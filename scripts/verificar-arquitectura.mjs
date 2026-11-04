import assert from "node:assert/strict";
import { readFileSync, readdirSync } from "node:fs";
import { dirname, join, relative } from "node:path";
import { fileURLToPath } from "node:url";

const raiz = join(dirname(fileURLToPath(import.meta.url)), "..");
const backend = join(raiz, "backend", "src");

function listar(directorio) {
  const archivos = [];
  for (const entrada of readdirSync(directorio, { withFileTypes: true })) {
    if (["bin", "obj", "node_modules"].includes(entrada.name)) {
      continue;
    }
    const ruta = join(directorio, entrada.name);
    if (entrada.isDirectory()) {
      archivos.push(...listar(ruta));
    } else {
      archivos.push(ruta);
    }
  }
  return archivos;
}

for (const archivo of listar(backend)) {
  if (!archivo.endsWith(".cs") && !archivo.endsWith(".csproj")) {
    continue;
  }
  const codigo = readFileSync(archivo, "utf8");
  const ruta = relative(backend, archivo).replaceAll("\\", "/");
  assert.doesNotMatch(codigo, /MediatR|IRequest|IPipelineBehavior|ISender/, ruta);

  if (ruta.includes("/Controllers/")) {
    assert.doesNotMatch(codigo, /User\.|Guid\.Parse|Claims|Repository|Validator|throw|\bif\s*\(/, ruta);
  }
  if (archivo.endsWith("Command.cs") || archivo.endsWith("Query.cs")) {
    assert.doesNotMatch(codigo, /\b\w+Dto\b|Repository|DbContext|Validator|Handle\(/, ruta);
  }
  if (ruta.includes("/Readers/") || ruta.includes("/Handlers/") ||
      archivo.endsWith("Handler.cs") || archivo.endsWith("Validator.cs")) {
    assert.doesNotMatch(codigo, /DbContext|EntityFrameworkCore|_context\.|FromSql|SaveChanges/, ruta);
  }
  if (!ruta.includes("/Repositories/")) {
    assert.doesNotMatch(codigo, /_context\.|\.SaveChangesAsync\(|\.FindAsync\(|\.ToListAsync\(|\.FromSqlInterpolated\(/, ruta);
  }
}

for (const [carpeta, nombre] of [
  ["CrearComanda", "CrearComanda"],
  ["InicioSesion", "IniciarSesion"]
]) {
  const ruta = join(backend, "Tacomanda.Application", carpeta, nombre + "Mediator.cs");
  const codigo = readFileSync(ruta, "utf8");
  const validacion = codigo.indexOf("_validator.Validar(solicitud);");
  const handler = codigo.indexOf("_handler.Handle(solicitud, cancellationToken)");
  assert.ok(validacion >= 0 && handler > validacion, nombre + ": validar antes del handler");
}

console.log("OK: commands y queries sin DTO de retorno ni bibliotecas de mediación.");
console.log("OK: controllers sin reglas, repositorios ni lectura de JWT.");
console.log("OK: mediadores propios invocan validator y después handler.");
console.log("OK: operaciones de consulta y guardado concentradas en repositories.");
