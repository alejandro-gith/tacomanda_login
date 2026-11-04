export interface ComandaDto {
  readonly id: string;
  readonly mesaId: string;
  readonly meseroId: string;
  readonly estado: string;
  readonly fechaCreacion: string;
  readonly total: number;
  readonly detalles: ReadonlyArray<{
    readonly platilloId: string;
    readonly nombre: string;
    readonly precioUnitario: number;
    readonly cantidad: number;
    readonly observaciones: string;
    readonly subtotal: number;
  }>;
}
