import { inject } from "@angular/core";
import { Router, UrlTree } from "@angular/router";
import { SessionStore } from "./SessionStore";

export function cierreGuard(): boolean | UrlTree {
  const store = inject(SessionStore);
  const router = inject(Router);
  if (store.tokenVigente() !== null && ["Cajero", "Administrador"].includes(store.sesion()?.rol ?? "")) return true;
  return router.createUrlTree(["/login"]);
}
