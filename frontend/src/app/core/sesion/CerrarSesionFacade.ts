import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { SessionStore } from "./SessionStore";

@Injectable({ providedIn: "root" })
export class CerrarSesionFacade {
  constructor(private readonly store: SessionStore, private readonly router: Router) { }

  async cerrar(): Promise<void> {
    this.store.limpiar();
    await this.router.navigate(["/login"]);
  }
}
