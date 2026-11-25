import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { CierreCajaApiClient } from "../../core/api/CierreCajaApiClient";
import { CierreCajaViewModel } from "./CierreCajaViewModel";
import { SessionStore } from "../../core/sesion/SessionStore";

@Injectable()
export class CierreCajaFacade {
  constructor(private readonly api: CierreCajaApiClient, private readonly vm: CierreCajaViewModel,
    private readonly sesion: SessionStore) { }

  destino(): string {
    return this.sesion.sesion()?.rol === "Administrador" ? "/administracion" : "/caja";
  }

  async consultar(): Promise<void> {
    this.vm.loading.set(true);
    try {
      const resumen = await firstValueFrom(this.api.consultarResumen());
      this.vm.totalSistema.set(resumen.totalSistema);
    } catch (error) {
      console.error("Error en el resumen de caja", error);
      this.vm.error.set("Error en el sistema.");
    } finally {
      this.vm.loading.set(false);
    }
  }

  async registrar(): Promise<void> {
    if (this.vm.loading() || this.vm.totalSistema() === null ||
        this.vm.totalContado() < 0 || !Number.isFinite(this.vm.totalContado())) return;
    this.vm.loading.set(true);
    this.vm.error.set("");
    try {
      const cierre = await firstValueFrom(this.api.registrar(this.vm.totalContado(),
        this.vm.huboIncidencias(), this.vm.comentarios().trim()));
      this.vm.cierre.set(cierre);
      this.vm.totalSistema.set(0);
    } catch (error) {
      console.error("Error al registrar cierre de caja", error);
      this.vm.error.set("Error en el sistema.");
    } finally {
      this.vm.loading.set(false);
    }
  }
}
