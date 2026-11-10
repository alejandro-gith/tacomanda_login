import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { PlatillosApiClient } from "../../core/api/PlatillosApiClient";
import { EmpleadosApiClient } from "../../core/api/EmpleadosApiClient";
import { AdministracionViewModel } from "./AdministracionViewModel";

@Injectable()
export class AdministracionFacade {
  constructor(
    private readonly platillos: PlatillosApiClient,
    private readonly empleados: EmpleadosApiClient,
    private readonly vm: AdministracionViewModel
  ) { }

  async consultarPlatillos(): Promise<void> {
    this.vm.loading = true;
    try {
      this.vm.cargar(await firstValueFrom(this.platillos.consultar()));
    } catch {
      this.vm.error = "Error en el sistema.";
    } finally {
      this.vm.loading = false;
    }
  }

  async guardarPlatillo(): Promise<void> {
    if (this.vm.loading) { return; }
    if (!this.vm.precioValido) {
      this.vm.error = "El precio debe ser mayor que cero.";
      return;
    }
    this.vm.loading = true;
    this.vm.mensaje = "";
    this.vm.error = "";
    try {
      const datos = { ...this.vm.platillo, nombre: this.vm.platillo.nombre.trim(),
        categoria: this.vm.platillo.categoria.trim(), descripcion: this.vm.platillo.descripcion.trim() };
      let guardado;
      if (this.vm.editandoId) {
        guardado = await firstValueFrom(this.platillos.editar(this.vm.editandoId, datos));
      } else {
        guardado = await firstValueFrom(this.platillos.crear(datos));
      }
      this.vm.guardarPlatillo(guardado);
      this.vm.limpiarPlatillo();
      this.vm.mensaje = "Platillo guardado.";
    } catch {
      this.vm.error = "Error en el sistema.";
    } finally {
      this.vm.loading = false;
    }
  }

  async eliminarPlatillo(id: string): Promise<void> {
    if (this.vm.loading) { return; }
    this.vm.loading = true;
    this.vm.mensaje = "";
    this.vm.error = "";
    try {
      await firstValueFrom(this.platillos.eliminar(id));
      this.vm.quitarPlatillo(id);
      this.vm.mensaje = "Platillo desactivado.";
    } catch {
      this.vm.error = "Error en el sistema.";
    } finally {
      this.vm.loading = false;
    }
  }

  async altaEmpleado(): Promise<void> {
    if (this.vm.loading) { return; }
    this.vm.loading = true;
    this.vm.mensaje = "";
    this.vm.error = "";
    try {
      await firstValueFrom(this.empleados.alta({ ...this.vm.empleado,
        usuario: this.vm.empleado.usuario.trim(), nombre: this.vm.empleado.nombre.trim() }));
      this.vm.limpiarEmpleado();
      this.vm.mensaje = "Empleado registrado.";
    } catch {
      this.vm.error = "Error en el sistema.";
    } finally {
      this.vm.loading = false;
    }
  }
}
