import { inject } from "@angular/core";
import { Router, UrlTree } from "@angular/router";
import { SessionStore } from "./SessionStore";

export function cobroGuard(): boolean | UrlTree {
  const store = inject(SessionStore);
  const router = inject(Router);
  if (store.tokenVigente() !== null && ["Mesero", "Cajero"].includes(store.sesion()?.rol ?? "")) return true;
  return router.createUrlTree(["/login"]);
}
