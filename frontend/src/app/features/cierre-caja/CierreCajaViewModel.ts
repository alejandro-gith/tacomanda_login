import { Injectable, signal } from "@angular/core";
import { CierreCajaDto } from "../../core/api/CierreCajaApiClient";

@Injectable()
export class CierreCajaViewModel {
  readonly totalSistema = signal<number | null>(null);
  readonly totalContado = signal(0);
  readonly huboIncidencias = signal(false);
  readonly comentarios = signal("");
  readonly cierre = signal<CierreCajaDto | null>(null);
  readonly loading = signal(false);
  readonly error = signal("");
}
