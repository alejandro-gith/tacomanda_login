import { Injectable, signal } from "@angular/core";
import { ComandaDto } from "../../core/modelos/ComandaDto";

@Injectable()
export class CambiarEstadoComandaViewModel {
  readonly comandas = signal<ReadonlyArray<ComandaDto>>([]);
  readonly loading = signal(false);
  readonly error = signal("");
  actualizar(comanda: ComandaDto): void {
    this.comandas.update(actuales => actuales.map(c => c.id === comanda.id ? comanda : c));
  }
}
