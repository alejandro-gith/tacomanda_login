import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { SessionStore } from "./session.store";

export const authInterceptor: HttpInterceptorFn = (request, next) => {
  const token = inject(SessionStore).session()?.accessToken;
  return next(
    token
      ? request.clone({ setHeaders: { Authorization: `Bearer ${token}` } })
      : request,
  );
};
