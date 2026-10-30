import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { Role } from "./role.model";
import { SessionStore } from "./session.store";
import { homeForRole } from "./auth.service";

export const roleGuard =
  (role: Role): CanActivateFn =>
  () => {
    const store = inject(SessionStore),
      router = inject(Router),
      session = store.session();
    if (!store.authenticated() || !session)
      return router.createUrlTree(["/login"]);
    return session.role === role
      ? true
      : router.createUrlTree([homeForRole(session.role)]);
  };
