import { Injectable } from "@angular/core";
import { firstValueFrom, timeout } from "rxjs";
import { ComandasApiClient } from "../../core/api/ComandasApiClient";
import { MesasApiClient } from "../../core/api/MesasApiClient";
import { PlatillosApiClient } from "../../core/api/PlatillosApiClient";
import { DetalleComandaInput } from "../../core/modelos/DetalleComandaInput";
import { CrearComandaViewModel } from "./CrearComandaViewModel";

@Injectable()
export class CrearComandaFacade {
  constructor(
    private readonly comandas: ComandasApiClient,
    private readonly mesas: MesasApiClient,
    private readonly platillos: PlatillosApiClient,
    private readonly vm: CrearComandaViewModel
  ) { }

  async inicializar(): Promise<void> {
    this.vm.iniciarCarga();
    try {
      const [platillos, mesas] = await Promise.all([
        firstValueFrom(this.platillos.consultar().pipe(timeout(15000))),
        firstValueFrom(this.mesas.consultar().pipe(timeout(15000)))
      ]);
      this.vm.cargarCatalogo(platillos, mesas);
    } catch (error) {
      console.error("Error al cargar platillos y mesas", error);
      this.vm.mostrarError();
    } finally {
      this.vm.finalizarCarga();
    }
  }

  async enviar(): Promise<void> {
    if (this.vm.loading || this.vm.carrito.length === 0) {
      return;
    }
    if (!this.vm.mesaValida) {
      this.vm.mostrarMesaRequerida();
      return;
    }

    const detalles: DetalleComandaInput[] = [];
    for (const linea of this.vm.carrito) {
      detalles.push({
        platilloId: linea.platillo.id,
        cantidad: linea.cantidad,
        observaciones: linea.observaciones.trim()
      });
    }

    this.vm.iniciarCarga();
    try {
      const comanda = await firstValueFrom(this.comandas.crear({
        mesaId: this.vm.mesaId!,
        detalles
      }).pipe(timeout(15000)));
      this.vm.confirmar(comanda.numeroDiario, comanda.fechaOperativa);
      void this.refrescarMesas();
    } catch (error) {
      console.error("Error al crear comanda", error);
      this.vm.mostrarError();
    } finally {
      this.vm.finalizarCarga();
    }
  }

  private async refrescarMesas(): Promise<void> {
    try {
      this.vm.actualizarMesas(await firstValueFrom(this.mesas.consultar().pipe(timeout(15000))));
    } catch (error) {
      console.error("Error al actualizar mesas", error);
    }
  }
}
