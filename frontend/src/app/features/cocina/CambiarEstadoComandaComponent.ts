import { Component, OnDestroy, OnInit } from "@angular/core";
import { CurrencyPipe, DatePipe } from "@angular/common";
import { RouterLink } from "@angular/router";
import { CambiarEstadoComandaViewModel } from "./CambiarEstadoComandaViewModel";
import { CambiarEstadoComandaFacade } from "./CambiarEstadoComandaFacade";
import { CerrarSesionFacade } from "../../core/sesion/CerrarSesionFacade";

@Component({ selector: "app-cambiar-estado-comanda", standalone: true,
  imports: [CurrencyPipe, DatePipe, RouterLink], providers: [CambiarEstadoComandaViewModel, CambiarEstadoComandaFacade],
  templateUrl: "./cambiar-estado-comanda.component.html", styleUrl: "./cambiar-estado-comanda.component.css" })
export class CambiarEstadoComandaComponent implements OnInit, OnDestroy {
  private refresco?: ReturnType<typeof setInterval>;
  constructor(readonly vm: CambiarEstadoComandaViewModel, readonly facade: CambiarEstadoComandaFacade,
    readonly cierre: CerrarSesionFacade) { }
  ngOnInit(): void {
    void this.facade.consultar();
    this.refresco = setInterval(this.actualizar.bind(this), 10000);
  }
  ngOnDestroy(): void { if (this.refresco) clearInterval(this.refresco); }
  private actualizar(): void { void this.facade.consultar(); }
}
