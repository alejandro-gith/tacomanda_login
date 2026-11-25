import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { firstValueFrom, timeout } from "rxjs";
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

  async consultarUsuarios(): Promise<void> {
    if (this.vm.loadingUsuarios) {
      return;
    }

    this.vm.iniciarConsultaUsuarios();
    try {
      const usuarios = await firstValueFrom(this.api.consultarUsuarios().pipe(timeout(15000)));
      this.vm.cargarUsuarios(usuarios);
      if (usuarios.length === 0) {
        console.error("La API no devolvió usuarios disponibles para el turno.");
        this.vm.mostrarError();
      }
    } catch (error) {
      console.error("Error al consultar usuarios del turno", error);
      this.vm.cargarUsuarios([]);
      this.vm.mostrarError();
    } finally {
      this.vm.finalizarConsultaUsuarios();
    }
  }

  async iniciarSesion(): Promise<void> {
    if (this.vm.loading || this.vm.loadingUsuarios) {
      return;
    }
    const usuario = this.vm.usuario.trim();
    if (usuario.length === 0 || this.vm.password.length < 8 || this.vm.password.length > 128) {
      this.vm.mostrarError();
      return;
    }

    this.vm.iniciarCarga();
    try {
      const sesion = await firstValueFrom(
        this.api.iniciarSesion(usuario, this.vm.password).pipe(timeout(15000)));
      this.store.guardar(sesion);
      if (sesion.rol === "Mesero") {
        await this.router.navigate(["/comandas/crear"]);
      } else if (sesion.rol === "Administrador") {
        await this.router.navigate(["/administracion"]);
      } else if (sesion.rol === "Cocinero") {
        await this.router.navigate(["/cocina"]);
      } else if (sesion.rol === "Cajero") {
        await this.router.navigate(["/caja"]);
      } else {
        this.store.limpiar();
        this.vm.mostrarError();
      }
    } catch (error) {
      console.error("Error al iniciar sesión", error);
      this.vm.mostrarError();
    } finally {
      this.vm.finalizarCarga();
    }
  }
}
