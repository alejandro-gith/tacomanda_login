import { Injectable, signal } from "@angular/core";
import { Sesion } from "../modelos/Sesion";

@Injectable({ providedIn: "root" })
export class SessionStore {
  private readonly storageKey = "tacomanda.crc.sesion";
  private readonly estado = signal<Sesion | null>(null);
  readonly sesion = this.estado.asReadonly();

  constructor() {
    const guardada = sessionStorage.getItem(this.storageKey);
    if (guardada !== null) {
      try {
        const dato: Sesion = JSON.parse(guardada);
        if (typeof dato.accessToken === "string" && typeof dato.rol === "string" &&
            Date.parse(dato.expiraEn) > Date.now()) {
          this.estado.set(Object.freeze(dato));
        } else {
          this.limpiar();
        }
      } catch {
        this.limpiar();
      }
    }
  }

  guardar(sesion: Sesion): void {
    this.estado.set(Object.freeze({ ...sesion }));
    sessionStorage.setItem(this.storageKey, JSON.stringify(sesion));
  }

  limpiar(): void {
    this.estado.set(null);
    sessionStorage.removeItem(this.storageKey);
  }

  tokenVigente(): string | null {
    const actual = this.estado();
    if (actual === null || Date.parse(actual.expiraEn) <= Date.now()) {
      this.limpiar();
      return null;
    }
    return actual.accessToken;
  }
}
