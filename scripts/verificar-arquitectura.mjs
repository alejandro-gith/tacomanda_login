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
  if (ruta.includes("/Controllers/")) {
    assert.match(codigo, /ISender/, ruta);
  }

  if (ruta.includes("/Controllers/")) {
    assert.doesNotMatch(codigo, /User\.|Guid\.Parse|Claims|Repository|Validator|throw|\bif\s*\(/, ruta);
  }
  if (archivo.endsWith("Command.cs") || archivo.endsWith("Query.cs")) {
    assert.doesNotMatch(codigo, /Repository|DbContext|Validator|Handle\(/, ruta);
  }
  if (ruta.includes("/Readers/") || ruta.includes("/Handlers/") ||
      archivo.endsWith("Handler.cs") || archivo.endsWith("Validator.cs")) {
    assert.doesNotMatch(codigo, /DbContext|EntityFrameworkCore|_context\.|FromSql|SaveChanges/, ruta);
  }
  if (!ruta.includes("/Repositories/")) {
    assert.doesNotMatch(codigo, /_context\.|\.SaveChangesAsync\(|\.FindAsync\(|\.ToListAsync\(|\.FromSqlInterpolated\(/, ruta);
  }
}

const pipeline = readFileSync(join(backend, "Tacomanda.Application", "Validacion", "ValidationBehavior.cs"), "utf8");
assert.match(pipeline, /validator\.Validar\(request\)/);
assert.ok(pipeline.indexOf("validator.Validar(request)") < pipeline.indexOf("next()"));
const handler = readFileSync(join(backend, "Tacomanda.Application", "CrearComanda", "CrearComandaHandler.cs"), "utf8");
assert.match(handler, /IMeseroRepository/);
assert.doesNotMatch(handler, /IMeseroReader/);

console.log("OK: MediatR usa ISender, IRequest y handlers.");
console.log("OK: controllers sin reglas, repositorios ni lectura de JWT.");
console.log("OK: pipeline valida antes del handler; mesero usa repositorio directo.");
console.log("OK: operaciones de consulta y guardado concentradas en repositories.");
