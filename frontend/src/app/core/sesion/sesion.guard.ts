import { inject } from "@angular/core";
import { Router, UrlTree } from "@angular/router";
import { SessionStore } from "./SessionStore";

export function sesionGuard(): boolean | UrlTree {
  const store = inject(SessionStore);
  const router = inject(Router);
  if (store.tokenVigente() !== null) return true;
  return router.createUrlTree(["/login"]);
}
