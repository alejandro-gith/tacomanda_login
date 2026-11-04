import { DetalleComandaInput } from "./DetalleComandaInput";

export interface CrearComandaRequest {
  readonly mesaId: string;
  readonly detalles: ReadonlyArray<DetalleComandaInput>;
}
