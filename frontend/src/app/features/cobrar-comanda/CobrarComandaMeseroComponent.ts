import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { CurrencyPipe } from "@angular/common";
import { ComandaDto } from "../../core/modelos/ComandaDto";
import { CobrarComandaMeseroViewModel } from "./CobrarComandaMeseroViewModel";
import { CobrarComandaMeseroFacade } from "./CobrarComandaMeseroFacade";

@Component({ selector: "app-cobrar-comanda-mesero", standalone: true, imports: [CurrencyPipe],
  providers: [CobrarComandaMeseroViewModel, CobrarComandaMeseroFacade], template: `
    <section class="card"><h3>Cobrar comanda #{{ comanda.numeroDiario }}</h3>
      <p>Consumo: {{ comanda.total | currency:'MXN' }}</p>
      <label>Propina (opcional)
        <select [value]="vm.porcentajePropina()" (change)="vm.cambiarPorcentaje(+$any($event.target).value, comanda.total)">
          <option value="0">Sin propina</option><option value="15">15%</option>
          <option value="18">18%</option><option value="20">20%</option><option value="25">25%</option>
        </select>
      </label>
      <p>Propina: {{ vm.propina(comanda.total) | currency:'MXN' }}</p>
      <p><strong>Total a cobrar: {{ vm.totalConPropina(comanda.total) | currency:'MXN' }}</strong></p>
      <label>Forma de pago <select [value]="vm.forma()" (change)="cambiarForma($any($event.target).value)">
        <option value="Efectivo">Efectivo</option><option value="Tarjeta">Tarjeta</option></select></label>
      <label>Monto recibido <input type="number" [min]="vm.totalConPropina(comanda.total)" step="0.01" [value]="vm.monto()"
        (input)="vm.monto.set(+$any($event.target).value)"></label>
      @if (vm.error()) { <p role="alert">{{ vm.error() }}</p> }
      <button type="button" [disabled]="vm.loading() || vm.monto() < vm.totalConPropina(comanda.total) || (vm.forma() === 'Tarjeta' && vm.monto() !== vm.totalConPropina(comanda.total))"
        (click)="cobrar()">Confirmar cobro</button>
    </section>` })
export class CobrarComandaMeseroComponent implements OnInit {
  @Input({ required: true }) comanda!: ComandaDto;
  @Output() cobrada = new EventEmitter<ComandaDto>();
  constructor(readonly vm: CobrarComandaMeseroViewModel, readonly facade: CobrarComandaMeseroFacade) { }
  ngOnInit(): void { this.vm.monto.set(this.comanda.total); }
  cambiarForma(forma: "Efectivo" | "Tarjeta"): void {
    this.vm.forma.set(forma);
    this.vm.monto.set(this.vm.totalConPropina(this.comanda.total));
  }
  async cobrar(): Promise<void> {
    const respuesta = await this.facade.cobrar(this.comanda.id, this.comanda.total);
    if (respuesta) this.cobrada.emit(respuesta);
  }
}
