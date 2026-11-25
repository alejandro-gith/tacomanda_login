import { Component, OnInit } from "@angular/core";
import { CurrencyPipe, DatePipe } from "@angular/common";
import { RouterLink } from "@angular/router";
import { ConsultarComandasViewModel } from "./ConsultarComandasViewModel";
import { ConsultarComandasFacade } from "./ConsultarComandasFacade";
import { EditarComandaComponent } from "../editar-comanda/EditarComandaComponent";
import { CobrarComandaMeseroComponent } from "../cobrar-comanda/CobrarComandaMeseroComponent";
import { CerrarSesionFacade } from "../../core/sesion/CerrarSesionFacade";

@Component({ selector: "app-consultar-comandas", standalone: true,
  imports: [CurrencyPipe, DatePipe, RouterLink, EditarComandaComponent, CobrarComandaMeseroComponent],
  providers: [ConsultarComandasViewModel, ConsultarComandasFacade],
  templateUrl: "./consultar-comandas.component.html", styleUrl: "./consultar-comandas.component.css" })
export class ConsultarComandasComponent implements OnInit {
  constructor(readonly vm: ConsultarComandasViewModel, readonly facade: ConsultarComandasFacade,
    readonly cierre: CerrarSesionFacade) { }
  ngOnInit(): void { void this.facade.consultar(); }
}
