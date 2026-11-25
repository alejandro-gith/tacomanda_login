import { Injectable, signal } from "@angular/core";
import { UsuarioDisponibleDto } from "../../core/api/AuthApiClient";

@Injectable()
export class InicioSesionViewModel {
  private readonly _usuario = signal("");
  private readonly _password = signal("");
  private readonly _loading = signal(false);
  private readonly _loadingUsuarios = signal(false);
  private readonly _mensaje = signal("");
  private readonly _usuarios = signal<ReadonlyArray<UsuarioDisponibleDto>>([]);

  get usuario(): string { return this._usuario(); }
  set usuario(value: string) { this._usuario.set(value); }
  get password(): string { return this._password(); }
  set password(value: string) { this._password.set(value); }
  get loading(): boolean { return this._loading(); }
  get loadingUsuarios(): boolean { return this._loadingUsuarios(); }
  get mensaje(): string { return this._mensaje(); }
  get usuarios(): ReadonlyArray<UsuarioDisponibleDto> { return this._usuarios(); }

  cargarUsuarios(usuarios: ReadonlyArray<UsuarioDisponibleDto>): void {
    this._usuarios.set(Object.freeze([...usuarios]));
  }

  iniciarConsultaUsuarios(): void {
    this._loadingUsuarios.set(true);
    this._mensaje.set("");
  }

  finalizarConsultaUsuarios(): void {
    this._loadingUsuarios.set(false);
  }

  iniciarCarga(): void {
    this._loading.set(true);
    this._mensaje.set("");
  }

  finalizarCarga(): void {
    this._loading.set(false);
    this._password.set("");
  }

  mostrarError(): void {
    this._mensaje.set("Error en el sistema.");
  }
}
