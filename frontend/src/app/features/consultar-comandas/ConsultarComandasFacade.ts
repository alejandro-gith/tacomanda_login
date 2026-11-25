import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ComandasApiClient } from "../../core/api/ComandasApiClient";
import { ConsultarComandasViewModel } from "./ConsultarComandasViewModel";

@Injectable()
export class ConsultarComandasFacade {
  constructor(private readonly api: ComandasApiClient, private readonly vm: ConsultarComandasViewModel) { }
  async consultar(): Promise<void> {
    this.vm.loading.set(true);
    this.vm.error.set("");
    try {
      this.vm.comandas.set(await firstValueFrom(this.api.consultar(this.vm.estado() || undefined)));
    } catch (error) {
      console.error("Error al consultar comandas", error);
      this.vm.error.set("Error en el sistema.");
    } finally { this.vm.loading.set(false); }
  }
}
