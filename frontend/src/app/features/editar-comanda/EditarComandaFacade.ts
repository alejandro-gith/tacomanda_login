import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ComandasApiClient } from "../../core/api/ComandasApiClient";
import { PlatillosApiClient } from "../../core/api/PlatillosApiClient";
import { ComandaDto } from "../../core/modelos/ComandaDto";
import { EditarComandaViewModel } from "./EditarComandaViewModel";

@Injectable()
export class EditarComandaFacade {
  constructor(private readonly api: ComandasApiClient, private readonly catalogo: PlatillosApiClient,
    private readonly vm: EditarComandaViewModel) { }
  async cargarCatalogo(): Promise<void> {
    try { this.vm.platillos.set(await firstValueFrom(this.catalogo.consultar())); }
    catch (error) { console.error("Error al cargar menú", error); this.vm.error.set("Error en el sistema."); }
  }
  async guardar(id: number): Promise<ComandaDto | null> {
    if (this.vm.loading() || this.vm.detalles().length < 1 || this.vm.detalles().some(d => d.cantidad < 1 || d.cantidad > 99)) return null;
    this.vm.loading.set(true);
    this.vm.error.set("");
    try { return await firstValueFrom(this.api.editar(id, this.vm.detalles())); }
    catch (error) { console.error("Error al editar comanda", error); this.vm.error.set("Error en el sistema."); return null; }
    finally { this.vm.loading.set(false); }
  }
}
