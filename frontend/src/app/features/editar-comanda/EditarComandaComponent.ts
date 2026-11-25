import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { CurrencyPipe } from "@angular/common";
import { ComandaDto } from "../../core/modelos/ComandaDto";
import { EditarComandaViewModel } from "./EditarComandaViewModel";
import { EditarComandaFacade } from "./EditarComandaFacade";

@Component({ selector: "app-editar-comanda", standalone: true, imports: [CurrencyPipe],
  providers: [EditarComandaViewModel, EditarComandaFacade], template: `
  <section class="card"><h3>Editar comanda pendiente</h3>
    @if (vm.error()) { <p role="alert">{{ vm.error() }}</p> }
    @for (d of vm.detalles(); track d.platilloId) {
      <div><b>{{ nombre(d.platilloId) }}</b>
        <input type="number" min="1" max="99" [value]="d.cantidad" (input)="vm.cambiarCantidad(d.platilloId, +$any($event.target).value)">
        <input maxlength="200" placeholder="Observaciones" [value]="d.observaciones" (input)="vm.cambiarNota(d.platilloId, $any($event.target).value)">
        <button type="button" (click)="vm.quitar(d.platilloId)">Quitar</button></div>
    }
    <select #nuevo><option value="">Añadir platillo</option>
      @for (p of vm.platillos(); track p.id) { <option [value]="p.id">{{ p.nombre }} · {{ p.precio | currency:'MXN' }}</option> }
    </select><button type="button" (click)="vm.agregar(+nuevo.value); nuevo.value = ''">Añadir</button>
    <button type="button" [disabled]="vm.loading() || !vm.detalles().length" (click)="guardar()">Guardar cambios</button>
  </section>` })
export class EditarComandaComponent implements OnInit {
  @Input({ required: true }) comanda!: ComandaDto;
  @Output() actualizada = new EventEmitter<ComandaDto>();
  constructor(readonly vm: EditarComandaViewModel, readonly facade: EditarComandaFacade) { }
  ngOnInit(): void { this.vm.cargar(this.comanda); void this.facade.cargarCatalogo(); }
  nombre(id: number): string { return this.vm.platillos().find(p => p.id === id)?.nombre ??
    this.comanda.detalles.find(d => d.platilloId === id)?.nombre ?? String(id); }
  async guardar(): Promise<void> {
    const respuesta = await this.facade.guardar(this.comanda.id);
    if (respuesta) this.actualizada.emit(respuesta);
  }
}
