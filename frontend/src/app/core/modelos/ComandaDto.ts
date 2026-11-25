export interface ComandaDto {
  readonly id: number;
  readonly fechaOperativa: string;
  readonly numeroDiario: number;
  readonly mesaId: number;
  readonly meseroId: number;
  readonly estado: string;
  readonly fechaCreacion: string;
  readonly total: number;
  readonly formaPago: string | null;
  readonly montoPagado: number | null;
  readonly porcentajePropina: number;
  readonly propina: number;
  readonly totalConPropina: number;
  readonly fechaCobro: string | null;
  readonly detalles: ReadonlyArray<{
    readonly platilloId: number;
    readonly nombre: string;
    readonly precioUnitario: number;
    readonly cantidad: number;
    readonly observaciones: string;
    readonly subtotal: number;
  }>;
}
