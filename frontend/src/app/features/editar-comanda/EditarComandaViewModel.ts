import { Injectable, signal } from "@angular/core";
import { ComandaDto } from "../../core/modelos/ComandaDto";
import { DetalleComandaInput } from "../../core/modelos/DetalleComandaInput";
import { PlatilloDto } from "../../core/modelos/PlatilloDto";

@Injectable()
export class EditarComandaViewModel {
  readonly detalles = signal<DetalleComandaInput[]>([]);
  readonly platillos = signal<ReadonlyArray<PlatilloDto>>([]);
  readonly loading = signal(false);
  readonly error = signal("");
  cargar(comanda: ComandaDto): void {
    this.detalles.set(comanda.detalles.map(d => ({ platilloId: d.platilloId, cantidad: d.cantidad, observaciones: d.observaciones })));
  }
  cambiarCantidad(id: number, cantidad: number): void {
    this.detalles.update(actuales => actuales.map(d => d.platilloId === id ? { ...d, cantidad } : d));
  }
  cambiarNota(id: number, observaciones: string): void {
    this.detalles.update(actuales => actuales.map(d => d.platilloId === id ? { ...d, observaciones } : d));
  }
  quitar(id: number): void { this.detalles.update(actuales => actuales.filter(d => d.platilloId !== id)); }
  agregar(id: number): void {
    if (id && !this.detalles().some(d => d.platilloId === id))
      this.detalles.update(actuales => [...actuales, { platilloId: id, cantidad: 1, observaciones: "" }]);
  }
}
