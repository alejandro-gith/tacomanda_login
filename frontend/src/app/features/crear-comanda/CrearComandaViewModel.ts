import { Injectable } from "@angular/core";
import { MesaDto } from "../../core/modelos/MesaDto";
import { PlatilloDto } from "../../core/modelos/PlatilloDto";
import { LineaCarrito } from "./LineaCarrito";

@Injectable()
export class CrearComandaViewModel {
  private _platillos: ReadonlyArray<PlatilloDto> = [];
  private _mesas: ReadonlyArray<MesaDto> = [];
  private _carrito: ReadonlyArray<LineaCarrito> = [];
  private _mesaId = "";
  private _categoria = "Todos";
  private _loading = false;
  private _error = "";
  private _resultado = "";

  get mesas(): ReadonlyArray<MesaDto> { return this._mesas; }
  get carrito(): ReadonlyArray<LineaCarrito> { return this._carrito; }
  get mesaId(): string { return this._mesaId; }
  get categoria(): string { return this._categoria; }
  get loading(): boolean { return this._loading; }
  get error(): string { return this._error; }
  get resultado(): string { return this._resultado; }

  get categorias(): ReadonlyArray<string> {
    const categorias = new Set<string>(["Todos"]);
    for (const platillo of this._platillos) {
      categorias.add(platillo.categoria);
    }
    return Array.from(categorias);
  }

  get visibles(): ReadonlyArray<PlatilloDto> {
    const visibles: PlatilloDto[] = [];
    for (const platillo of this._platillos) {
      if (this._categoria === "Todos" || platillo.categoria === this._categoria) {
        visibles.push(platillo);
      }
    }
    return visibles;
  }

  get cantidadTotal(): number {
    let cantidad = 0;
    for (const linea of this._carrito) {
      cantidad += linea.cantidad;
    }
    return cantidad;
  }

  get total(): number {
    let centavos = 0;
    for (const linea of this._carrito) {
      centavos += Math.round(linea.platillo.precio * 100) * linea.cantidad;
    }
    return centavos / 100;
  }

  cargarCatalogo(platillos: ReadonlyArray<PlatilloDto>, mesas: ReadonlyArray<MesaDto>): void {
    this._platillos = Object.freeze([...platillos]);
    this._mesas = Object.freeze([...mesas]);
  }

  actualizarMesas(mesas: ReadonlyArray<MesaDto>): void {
    this._mesas = Object.freeze([...mesas]);
  }

  seleccionarMesa(id: string): void {
    this._mesaId = id;
  }

  seleccionarCategoria(categoria: string): void {
    this._categoria = categoria;
  }

  cantidad(id: string): number {
    for (const linea of this._carrito) {
      if (linea.platillo.id === id) {
        return linea.cantidad;
      }
    }
    return 0;
  }

  agregar(platillo: PlatilloDto): void {
    if (this._loading) {
      return;
    }
    if (this.cantidad(platillo.id) > 0) {
      this.cambiarCantidad(platillo.id, 1);
    } else {
      this._carrito = Object.freeze([
        ...this._carrito,
        Object.freeze({ platillo: Object.freeze({ ...platillo }), cantidad: 1, observaciones: "" })
      ]);
    }
    this._resultado = "";
  }

  cambiarCantidad(id: string, cambio: number): void {
    if (this._loading) {
      return;
    }
    const nuevas: LineaCarrito[] = [];
    for (const linea of this._carrito) {
      const cantidad = linea.platillo.id === id ? linea.cantidad + cambio : linea.cantidad;
      if (cantidad > 0) {
        nuevas.push(Object.freeze({ ...linea, cantidad: Math.min(cantidad, 99) }));
      }
    }
    this._carrito = Object.freeze(nuevas);
  }

  cambiarObservaciones(id: string, observaciones: string): void {
    if (this._loading) {
      return;
    }
    const nuevas: LineaCarrito[] = [];
    for (const linea of this._carrito) {
      if (linea.platillo.id === id) {
        nuevas.push(Object.freeze({ ...linea, observaciones }));
      } else {
        nuevas.push(linea);
      }
    }
    this._carrito = Object.freeze(nuevas);
  }

  iniciarCarga(): void {
    this._loading = true;
    this._error = "";
    this._resultado = "";
  }

  finalizarCarga(): void {
    this._loading = false;
  }

  mostrarError(): void {
    this._error = "Error en el sistema.";
  }

  confirmar(id: string): void {
    this._carrito = [];
    this._mesaId = "";
    this._resultado = "Comanda " + id.slice(0, 8) + " registrada.";
  }

  limpiar(): void {
    if (!this._loading) {
      this._carrito = [];
      this._mesaId = "";
      this._resultado = "";
    }
  }
}
