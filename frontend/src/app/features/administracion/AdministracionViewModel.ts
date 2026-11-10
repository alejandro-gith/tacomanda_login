import { Injectable, signal } from "@angular/core";
import { AltaEmpleadoRequest } from "../../core/api/EmpleadosApiClient";
import { PlatilloRequest } from "../../core/api/PlatillosApiClient";
import { PlatilloDto } from "../../core/modelos/PlatilloDto";

@Injectable()
export class AdministracionViewModel {
  private readonly _platillos = signal<ReadonlyArray<PlatilloDto>>([]);
  private readonly _platillo = signal<PlatilloRequest>(this.nuevoPlatillo());
  private readonly _empleado = signal<AltaEmpleadoRequest>(this.nuevoEmpleado());
  private readonly _editandoId = signal<string | null>(null);
  private readonly _loading = signal(false);
  private readonly _mensaje = signal("");
  private readonly _error = signal("");

  get platillos(): ReadonlyArray<PlatilloDto> { return this._platillos(); }
  get platillo(): PlatilloRequest { return this._platillo(); }
  set platillo(valor: PlatilloRequest) { this._platillo.set(valor); }
  get empleado(): AltaEmpleadoRequest { return this._empleado(); }
  set empleado(valor: AltaEmpleadoRequest) { this._empleado.set(valor); }
  get editandoId(): string | null { return this._editandoId(); }
  set editandoId(valor: string | null) { this._editandoId.set(valor); }
  get loading(): boolean { return this._loading(); }
  set loading(valor: boolean) { this._loading.set(valor); }
  get mensaje(): string { return this._mensaje(); }
  set mensaje(valor: string) { this._mensaje.set(valor); }
  get error(): string { return this._error(); }
  set error(valor: string) { this._error.set(valor); }

  get precioValido(): boolean {
    return Number.isFinite(this.platillo.precio) && this.platillo.precio > 0;
  }

  cargar(platillos: ReadonlyArray<PlatilloDto>): void {
    this._platillos.set(Object.freeze([...platillos]));
  }

  guardarPlatillo(platillo: PlatilloDto): void {
    const actualizados = this.platillos.filter(actual => actual.id !== platillo.id);
    actualizados.push(platillo);
    actualizados.sort((a, b) => a.nombre.localeCompare(b.nombre));
    this._platillos.set(Object.freeze(actualizados));
  }

  quitarPlatillo(id: string): void {
    this._platillos.set(Object.freeze(this.platillos.filter(platillo => platillo.id !== id)));
  }

  editar(platillo: PlatilloDto): void {
    this.editandoId = platillo.id;
    this.platillo = { nombre: platillo.nombre, categoria: platillo.categoria,
      descripcion: platillo.descripcion, precio: platillo.precio, emoji: platillo.emoji };
    this.error = "";
  }

  limpiarPlatillo(): void {
    this.editandoId = null;
    this.platillo = this.nuevoPlatillo();
  }

  limpiarEmpleado(): void {
    this.empleado = this.nuevoEmpleado();
  }

  private nuevoPlatillo(): PlatilloRequest {
    return { nombre: "", categoria: "", descripcion: "", precio: 0, emoji: "🌮" };
  }

  private nuevoEmpleado(): AltaEmpleadoRequest {
    return { usuario: "", nombre: "", password: "", rol: "Mesero" };
  }
}
