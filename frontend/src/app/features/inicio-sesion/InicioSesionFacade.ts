import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { firstValueFrom } from "rxjs";
import { AuthApiClient } from "../../core/api/AuthApiClient";
import { SessionStore } from "../../core/sesion/SessionStore";
import { InicioSesionViewModel } from "./InicioSesionViewModel";

@Injectable()
export class InicioSesionFacade {
  constructor(
    private readonly api: AuthApiClient,
    private readonly store: SessionStore,
    private readonly router: Router,
    private readonly vm: InicioSesionViewModel
  ) { }

  async iniciarSesion(): Promise<void> {
    if (this.vm.loading) {
      return;
    }
    const usuario = this.vm.usuario.trim();
    if (usuario.length === 0 || this.vm.password.length < 8 || this.vm.password.length > 128) {
      this.vm.mostrarError();
      return;
    }

    this.vm.iniciarCarga();
    try {
      const sesion = await firstValueFrom(this.api.iniciarSesion(usuario, this.vm.password));
      this.store.guardar(sesion);
      if (sesion.rol === "Mesero") {
        await this.router.navigate(["/comandas/crear"]);
      } else {
        this.store.limpiar();
        this.vm.mostrarError();
      }
    } catch {
      this.vm.mostrarError();
    } finally {
      this.vm.finalizarCarga();
    }
  }
}
