import { inject } from "@angular/core";
import { HttpRequest, HttpHandlerFn, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { SessionStore } from "../sesion/SessionStore";
import { environment } from "../../../environments/environment";

export function authInterceptor(
  request: HttpRequest<unknown>, next: HttpHandlerFn
): Observable<HttpEvent<unknown>> {
  const store = inject(SessionStore);
  const token = store.tokenVigente();

  if (token !== null && request.url.startsWith(environment.apiUrl + "/")) {
    return next(request.clone({ setHeaders: { Authorization: "Bearer " + token } }));
  }
  return next(request);
}
