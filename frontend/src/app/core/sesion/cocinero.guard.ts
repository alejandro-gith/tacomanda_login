import { inject } from "@angular/core";
import { Router, UrlTree } from "@angular/router";
import { SessionStore } from "./SessionStore";

export function cocineroGuard(): boolean | UrlTree {
  const store = inject(SessionStore);
  const router = inject(Router);
  return store.tokenVigente() !== null && store.sesion()?.rol === "Cocinero"
    ? true : router.createUrlTree(["/login"]);
}
