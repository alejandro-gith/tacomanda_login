import { Injectable, signal } from "@angular/core";
import { ComandaDto } from "../../core/modelos/ComandaDto";

@Injectable()
export class TicketViewModel {
  readonly comanda = signal<ComandaDto | null>(null);
  readonly error = signal("");
  readonly loading = signal(false);
}
