import { Injectable, signal } from "@angular/core";

@Injectable()
export class CobrarComandaMeseroViewModel {
  readonly forma = signal<"Efectivo" | "Tarjeta">("Efectivo");
  readonly monto = signal(0);
  readonly porcentajePropina = signal(0);
  readonly loading = signal(false);
  readonly error = signal("");

  propina(total: number): number {
    return Math.round(Math.round(total * 100) * this.porcentajePropina() / 100) / 100;
  }

  totalConPropina(total: number): number {
    return Math.round(total * 100 + this.propina(total) * 100) / 100;
  }

  cambiarPorcentaje(porcentaje: number, total: number): void {
    this.porcentajePropina.set(porcentaje);
    this.monto.set(this.totalConPropina(total));
  }
}
