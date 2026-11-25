import { Injectable, signal } from "@angular/core";
import { MesaDto } from "../../core/modelos/MesaDto";
import { PlatilloDto } from "../../core/modelos/PlatilloDto";
import { LineaCarrito } from "./LineaCarrito";

@Injectable()
export class CrearComandaViewModel {
  private readonly _platillos = signal<ReadonlyArray<PlatilloDto>>([]);
  private readonly _mesas = signal<ReadonlyArray<MesaDto>>([]);
  private readonly _carrito = signal<ReadonlyArray<LineaCarrito>>([]);
  private readonly _mesaId = signal<number | null>(null);
  private readonly _categoria = signal("Todos");
  private readonly _loading = signal(false);
  private readonly _error = signal("");
  private readonly _resultado = signal("");

  get mesas(): ReadonlyArray<MesaDto> { return this._mesas(); }
  get carrito(): ReadonlyArray<LineaCarrito> { return this._carrito(); }
  get mesaId(): number | null { return this._mesaId(); }
  get mesaValida(): boolean { return this.mesas.some(mesa => mesa.id === this.mesaId && mesa.disponible); }
  get categoria(): string { return this._categoria(); }
  get loading(): boolean { return this._loading(); }
  get error(): string { return this._error(); }
  get resultado(): string { return this._resultado(); }

  get categorias(): ReadonlyArray<string> {
    const categorias = new Set<string>(["Todos"]);
    for (const platillo of this._platillos()) {
      categorias.add(platillo.categoria);
    }
    return Array.from(categorias);
  }

  get visibles(): ReadonlyArray<PlatilloDto> {
    const visibles: PlatilloDto[] = [];
    for (const platillo of this._platillos()) {
      if (this._categoria() === "Todos" || platillo.categoria === this._categoria()) {
        visibles.push(platillo);
      }
    }
    return visibles;
  }

  get cantidadTotal(): number {
    let cantidad = 0;
    for (const linea of this._carrito()) {
      cantidad += linea.cantidad;
    }
    return cantidad;
  }

  get total(): number {
    let centavos = 0;
    for (const linea of this._carrito()) {
      centavos += Math.round(linea.platillo.precio * 100) * linea.cantidad;
    }
    return centavos / 100;
  }

  cargarCatalogo(platillos: ReadonlyArray<PlatilloDto>, mesas: ReadonlyArray<MesaDto>): void {
    this._platillos.set(Object.freeze([...platillos]));
    this.actualizarMesas(mesas);
  }

  actualizarMesas(mesas: ReadonlyArray<MesaDto>): void {
    this._mesas.set(Object.freeze([...mesas]));
    if (!this.mesaValida) this._mesaId.set(null);
  }

  seleccionarMesa(valor: string): void {
    const id = Number(valor);
    this._mesaId.set(this.mesas.some(mesa => mesa.id === id && mesa.disponible) ? id : null);
    this._error.set("");
  }

  seleccionarCategoria(categoria: string): void {
    this._categoria.set(categoria);
  }

  cantidad(id: number): number {
    for (const linea of this._carrito()) {
      if (linea.platillo.id === id) {
        return linea.cantidad;
      }
    }
    return 0;
  }

  agregar(platillo: PlatilloDto): void {
    if (this.loading) {
      return;
    }
    if (this.cantidad(platillo.id) > 0) {
      this.cambiarCantidad(platillo.id, 1);
    } else {
      this._carrito.set(Object.freeze([
        ...this._carrito(),
        Object.freeze({ platillo: Object.freeze({ ...platillo }), cantidad: 1, observaciones: "" })
      ]));
    }
    this._resultado.set("");
  }

  cambiarCantidad(id: number, cambio: number): void {
    if (this.loading) {
      return;
    }
    const nuevas: LineaCarrito[] = [];
    for (const linea of this._carrito()) {
      const cantidad = linea.platillo.id === id ? linea.cantidad + cambio : linea.cantidad;
      if (cantidad > 0) {
        nuevas.push(Object.freeze({ ...linea, cantidad: Math.min(cantidad, 99) }));
      }
    }
    this._carrito.set(Object.freeze(nuevas));
  }

  cambiarObservaciones(id: number, observaciones: string): void {
    if (this.loading) {
      return;
    }
    const nuevas: LineaCarrito[] = [];
    for (const linea of this._carrito()) {
      if (linea.platillo.id === id) {
        nuevas.push(Object.freeze({ ...linea, observaciones }));
      } else {
        nuevas.push(linea);
      }
    }
    this._carrito.set(Object.freeze(nuevas));
  }

  iniciarCarga(): void {
    this._loading.set(true);
    this._error.set("");
    this._resultado.set("");
  }

  finalizarCarga(): void {
    this._loading.set(false);
  }

  mostrarError(): void {
    this._error.set("Error en el sistema.");
  }

  mostrarMesaRequerida(): void {
    this._error.set("Selecciona una mesa disponible.");
  }

  confirmar(numeroDiario: number, fechaOperativa: string): void {
    const mesaId = this.mesaId;
    this._mesas.update(mesas => mesas.map(mesa => mesa.id === mesaId ? { ...mesa, disponible: false } : mesa));
    this._carrito.set([]);
    this._mesaId.set(null);
    this._resultado.set("Comanda #" + numeroDiario + " del " + fechaOperativa + " registrada.");
  }

  limpiar(): void {
    if (!this.loading) {
      this._carrito.set([]);
      this._mesaId.set(null);
      this._resultado.set("");
    }
  }
}
