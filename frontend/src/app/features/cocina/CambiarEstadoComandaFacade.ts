import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ComandasApiClient } from "../../core/api/ComandasApiClient";
import { CambiarEstadoComandaViewModel } from "./CambiarEstadoComandaViewModel";

@Injectable()
export class CambiarEstadoComandaFacade {
  constructor(private readonly api: ComandasApiClient, private readonly vm: CambiarEstadoComandaViewModel) { }
  async consultar(): Promise<void> {
    if (this.vm.loading()) return;
    this.vm.loading.set(true); this.vm.error.set("");
    try { this.vm.comandas.set(await firstValueFrom(this.api.consultar())); }
    catch (error) { console.error("Error en cocina", error); this.vm.error.set("Error en el sistema."); }
    finally { this.vm.loading.set(false); }
  }
  async cambiar(id: number, estado: "EnPreparacion" | "Lista"): Promise<void> {
    if (this.vm.loading()) return;
    this.vm.loading.set(true); this.vm.error.set("");
    try { this.vm.actualizar(await firstValueFrom(this.api.cambiarEstado(id, estado))); }
    catch (error) { console.error("Error al cambiar estado", error); this.vm.error.set("Error en el sistema."); }
    finally { this.vm.loading.set(false); }
  }
}
