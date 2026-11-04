import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { InicioSesionViewModel } from "./InicioSesionViewModel";
import { InicioSesionFacade } from "./InicioSesionFacade";

@Component({
  selector: "app-inicio-sesion",
  standalone: true,
  imports: [FormsModule],
  providers: [InicioSesionViewModel, InicioSesionFacade],
  templateUrl: "./inicio-sesion.component.html",
  styleUrl: "./inicio-sesion.component.css"
})
export class InicioSesionComponent {
  constructor(
    readonly vm: InicioSesionViewModel,
    readonly facade: InicioSesionFacade
  ) { }
}
