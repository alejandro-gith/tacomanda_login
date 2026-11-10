import { Component, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CurrencyPipe } from "@angular/common";
import { AdministracionViewModel } from "./AdministracionViewModel";
import { AdministracionFacade } from "./AdministracionFacade";
import { CerrarSesionFacade } from "../../core/sesion/CerrarSesionFacade";

@Component({
  selector: "app-administracion",
  standalone: true,
  imports: [FormsModule, CurrencyPipe],
  providers: [AdministracionViewModel, AdministracionFacade],
  templateUrl: "./administracion.component.html",
  styleUrl: "./administracion.component.css"
})
export class AdministracionComponent implements OnInit {
  constructor(
    readonly vm: AdministracionViewModel,
    readonly facade: AdministracionFacade,
    readonly cierre: CerrarSesionFacade
  ) { }

  ngOnInit(): void {
    void this.facade.consultarPlatillos();
  }
}
