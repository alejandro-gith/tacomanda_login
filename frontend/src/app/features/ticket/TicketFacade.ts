import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ComandasApiClient } from "../../core/api/ComandasApiClient";
import { TicketViewModel } from "./TicketViewModel";

@Injectable()
export class TicketFacade {
  constructor(private readonly api: ComandasApiClient, private readonly vm: TicketViewModel) { }

  async consultar(id: number): Promise<void> {
    this.vm.loading.set(true);
    try {
      const comanda = await firstValueFrom(this.api.consultarPorId(id));
      if (comanda.estado !== "Cobrada") throw new Error("La comanda no está cobrada.");
      this.vm.comanda.set(comanda);
    } catch (error) {
      console.error("No se pudo obtener el ticket", error);
      this.vm.error.set("Error en el sistema.");
    } finally {
      this.vm.loading.set(false);
    }
  }
}
