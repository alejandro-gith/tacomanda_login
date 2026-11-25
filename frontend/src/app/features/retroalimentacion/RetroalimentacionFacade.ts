import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { RetroalimentacionApiClient } from "../../core/api/RetroalimentacionApiClient";
import { RetroalimentacionViewModel } from "./RetroalimentacionViewModel";
import { SessionStore } from "../../core/sesion/SessionStore";

@Injectable()
export class RetroalimentacionFacade {
  constructor(private readonly api: RetroalimentacionApiClient,
    private readonly vm: RetroalimentacionViewModel,
    private readonly sesion: SessionStore) { }

  destino(): string {
    const rol = this.sesion.sesion()?.rol;
    if (rol === "Mesero") return "/comandas";
    if (rol === "Cajero") return "/caja";
    if (rol === "Cocinero") return "/cocina";
    return "/administracion";
  }

  async enviar(): Promise<void> {
    if (this.vm.loading() || this.vm.calificacion() < 1 || this.vm.calificacion() > 5) return;
    this.vm.loading.set(true);
    this.vm.error.set("");
    try {
      await firstValueFrom(this.api.registrar(this.vm.calificacion(), this.vm.comentario().trim()));
      this.vm.mensaje.set("Gracias por tu opinión.");
      this.vm.comentario.set("");
    } catch (error) {
      console.error("Error al registrar retroalimentación", error);
      this.vm.error.set("Error en el sistema.");
    } finally {
      this.vm.loading.set(false);
    }
  }
}
