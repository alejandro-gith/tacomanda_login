import { Component, OnInit } from "@angular/core";
import { CurrencyPipe } from "@angular/common";
import { CrearComandaViewModel } from "./CrearComandaViewModel";
import { CrearComandaFacade } from "./CrearComandaFacade";
import { SessionStore } from "../../core/sesion/SessionStore";
import { CerrarSesionFacade } from "../../core/sesion/CerrarSesionFacade";

@Component({
  selector: "app-crear-comanda",
  standalone: true,
  imports: [CurrencyPipe],
  providers: [CrearComandaViewModel, CrearComandaFacade],
  templateUrl: "./crear-comanda.component.html",
  styleUrl: "./crear-comanda.component.css"
})
export class CrearComandaComponent implements OnInit {
  constructor(
    readonly vm: CrearComandaViewModel,
    readonly facade: CrearComandaFacade,
    readonly sesion: SessionStore,
    readonly cierre: CerrarSesionFacade
  ) { }

  ngOnInit(): void {
    void this.facade.inicializar();
  }
}
