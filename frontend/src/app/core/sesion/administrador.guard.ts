import { inject } from "@angular/core";
import { Router, UrlTree } from "@angular/router";
import { SessionStore } from "./SessionStore";

export function administradorGuard(): boolean | UrlTree {
  const store = inject(SessionStore);
  const router = inject(Router);
  if (store.tokenVigente() !== null && store.sesion()?.rol === "Administrador") {
    return true;
  }
  return router.createUrlTree(["/login"]);
}
