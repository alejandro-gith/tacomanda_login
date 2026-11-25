import { Component, OnInit } from "@angular/core";
import { CurrencyPipe, DatePipe } from "@angular/common";
import { RouterLink } from "@angular/router";
import { CobrarComandaMeseroComponent } from "../cobrar-comanda/CobrarComandaMeseroComponent";
import { CerrarSesionFacade } from "../../core/sesion/CerrarSesionFacade";
import { CajaFacade } from "./CajaFacade";
import { CajaViewModel } from "./CajaViewModel";

@Component({
  selector: "app-caja",
  standalone: true,
  imports: [CurrencyPipe, DatePipe, RouterLink, CobrarComandaMeseroComponent],
  providers: [CajaFacade, CajaViewModel],
  templateUrl: "./caja.component.html",
  styleUrl: "./caja.component.css"
})
export class CajaComponent implements OnInit {
  constructor(readonly vm: CajaViewModel, readonly facade: CajaFacade,
    readonly cierre: CerrarSesionFacade) { }
  ngOnInit(): void { void this.facade.consultar(); }
}
