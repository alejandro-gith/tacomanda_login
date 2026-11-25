import { Component, OnInit } from "@angular/core";
import { CurrencyPipe, DatePipe } from "@angular/common";
import { RouterLink } from "@angular/router";
import { CierreCajaFacade } from "./CierreCajaFacade";
import { CierreCajaViewModel } from "./CierreCajaViewModel";

@Component({
  selector: "app-cierre-caja",
  standalone: true,
  imports: [CurrencyPipe, DatePipe, RouterLink],
  providers: [CierreCajaViewModel, CierreCajaFacade],
  templateUrl: "./cierre-caja.component.html",
  styleUrl: "./cierre-caja.component.css"
})
export class CierreCajaComponent implements OnInit {
  constructor(readonly vm: CierreCajaViewModel, readonly facade: CierreCajaFacade) { }
  ngOnInit(): void { void this.facade.consultar(); }
}
