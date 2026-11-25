import { Component } from "@angular/core";
import { RouterLink } from "@angular/router";
import { RetroalimentacionFacade } from "./RetroalimentacionFacade";
import { RetroalimentacionViewModel } from "./RetroalimentacionViewModel";

@Component({
  selector: "app-retroalimentacion",
  standalone: true,
  imports: [RouterLink],
  providers: [RetroalimentacionViewModel, RetroalimentacionFacade],
  templateUrl: "./retroalimentacion.component.html",
  styleUrl: "./retroalimentacion.component.css"
})
export class RetroalimentacionComponent {
  constructor(readonly vm: RetroalimentacionViewModel, readonly facade: RetroalimentacionFacade) { }
}
