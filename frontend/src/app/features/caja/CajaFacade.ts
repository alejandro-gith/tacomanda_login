import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ComandasApiClient } from "../../core/api/ComandasApiClient";
import { CajaViewModel } from "./CajaViewModel";

@Injectable()
export class CajaFacade {
  constructor(private readonly api: ComandasApiClient, private readonly vm: CajaViewModel) { }

  async consultar(): Promise<void> {
    this.vm.loading.set(true);
    this.vm.error.set("");
    try {
      this.vm.comandas.set(await firstValueFrom(this.api.consultar()));
    } catch (error) {
      console.error("Error al consultar caja", error);
      this.vm.error.set("Error en el sistema.");
    } finally {
      this.vm.loading.set(false);
    }
  }
}
