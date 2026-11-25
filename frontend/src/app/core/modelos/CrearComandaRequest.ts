import { DetalleComandaInput } from "./DetalleComandaInput";

export interface CrearComandaRequest {
  readonly mesaId: number;
  readonly detalles: ReadonlyArray<DetalleComandaInput>;
}
