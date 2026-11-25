import { Injectable, signal } from "@angular/core";

@Injectable()
export class RetroalimentacionViewModel {
  readonly calificacion = signal(5);
  readonly comentario = signal("");
  readonly loading = signal(false);
  readonly error = signal("");
  readonly mensaje = signal("");
}
