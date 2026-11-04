import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { SessionStore } from "./session.store";

export const authGuard: CanActivateFn = () => {
  const store = inject(SessionStore);
  return store.authenticated()
    ? true
    : inject(Router).createUrlTree(["/login"]);
};
