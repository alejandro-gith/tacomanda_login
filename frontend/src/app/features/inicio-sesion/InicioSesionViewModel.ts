import { Injectable } from "@angular/core";

@Injectable()
export class InicioSesionViewModel {
  private _usuario = "";
  private _password = "";
  private _loading = false;
  private _mensaje = "";

  get usuario(): string { return this._usuario; }
  set usuario(value: string) { this._usuario = value; }
  get password(): string { return this._password; }
  set password(value: string) { this._password = value; }
  get loading(): boolean { return this._loading; }
  get mensaje(): string { return this._mensaje; }

  iniciarCarga(): void {
    this._loading = true;
    this._mensaje = "";
  }

  finalizarCarga(): void {
    this._loading = false;
    this._password = "";
  }

  mostrarError(): void {
    this._mensaje = "Error en el sistema.";
  }
}
