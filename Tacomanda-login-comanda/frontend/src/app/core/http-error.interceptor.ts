import { HttpErrorResponse, HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { Router } from "@angular/router";
import { catchError, throwError } from "rxjs";
import { SessionStore } from "./session.store";

export const errorInterceptor: HttpInterceptorFn = (request, next) => {
  const store = inject(SessionStore);
  const router = inject(Router);
  return next(request).pipe(
    catchError((error: HttpErrorResponse) => {
      console.error("[TacoManda] HTTP error", {
        method: request.method,
        url: request.url,
        status: error.status,
        developerDetail: error.error,
      });
      if (error.status === 401 && !request.url.endsWith("/auth/login")) {
        store.clear();
        void router.navigateByUrl("/login");
      }
      return throwError(() => error);
    }),
  );
};
