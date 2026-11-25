import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { CobrosApiClient } from "../../core/api/CobrosApiClient";
import { ComandaDto } from "../../core/modelos/ComandaDto";
import { CobrarComandaMeseroViewModel } from "./CobrarComandaMeseroViewModel";

@Injectable()
export class CobrarComandaMeseroFacade {
  constructor(private readonly api: CobrosApiClient, private readonly vm: CobrarComandaMeseroViewModel) { }
  async cobrar(id: number, total: number): Promise<ComandaDto | null> {
    const aCobrar = this.vm.totalConPropina(total);
    if (this.vm.loading() || !Number.isFinite(this.vm.monto()) || this.vm.monto() < aCobrar ||
        (this.vm.forma() === "Tarjeta" && this.vm.monto() !== aCobrar)) return null;
    this.vm.loading.set(true); this.vm.error.set("");
    try { return await firstValueFrom(this.api.cobrar(id, this.vm.forma(), this.vm.monto(),
      this.vm.porcentajePropina())); }
    catch (error) { console.error("Error al cobrar comanda", error); this.vm.error.set("Error en el sistema."); return null; }
    finally { this.vm.loading.set(false); }
  }
}
