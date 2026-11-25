import { Injectable, signal } from "@angular/core";
import { ComandaDto } from "../../core/modelos/ComandaDto";

@Injectable()
export class CajaViewModel {
  readonly comandas = signal<ReadonlyArray<ComandaDto>>([]);
  readonly seleccionada = signal<ComandaDto | null>(null);
  readonly loading = signal(false);
  readonly error = signal("");

  actualizar(comanda: ComandaDto): void {
    this.comandas.update(actuales => actuales.map(actual => actual.id === comanda.id ? comanda : actual));
    this.seleccionada.set(null);
  }
}
