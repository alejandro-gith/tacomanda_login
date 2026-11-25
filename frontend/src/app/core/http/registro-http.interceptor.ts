import { HttpRequest, HttpHandlerFn, HttpEvent, HttpResponse } from "@angular/common/http";
import { Observable, tap } from "rxjs";

function registrarRespuesta(event: HttpEvent<unknown>): void {
  if (event instanceof HttpResponse) {
    console.info("Respuesta HTTP", event.status, event.url);
  }
}

function registrarError(error: unknown): void {
  console.error("Error HTTP", error);
}

export function registroHttpInterceptor(
  request: HttpRequest<unknown>, next: HttpHandlerFn
): Observable<HttpEvent<unknown>> {
  return next(request).pipe(tap({ next: registrarRespuesta, error: registrarError }));
}
