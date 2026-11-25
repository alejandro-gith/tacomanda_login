import { Injectable, signal } from "@angular/core";
import { ComandaDto } from "../../core/modelos/ComandaDto";

@Injectable()
export class ConsultarComandasViewModel {
  readonly comandas = signal<ReadonlyArray<ComandaDto>>([]);
  readonly loading = signal(false);
  readonly error = signal("");
  readonly estado = signal("");
  readonly seleccionada = signal<ComandaDto | null>(null);
  actualizar(comanda: ComandaDto): void {
    this.comandas.update(actuales => actuales.map(actual => actual.id === comanda.id ? comanda : actual));
    this.seleccionada.set(comanda);
  }
}
