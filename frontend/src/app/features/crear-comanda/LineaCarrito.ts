import { PlatilloDto } from "../../core/modelos/PlatilloDto";

export interface LineaCarrito {
  readonly platillo: PlatilloDto;
  readonly cantidad: number;
  readonly observaciones: string;
}
