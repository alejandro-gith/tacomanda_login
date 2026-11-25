import { Component, OnInit, signal } from "@angular/core";
import { CurrencyPipe, DatePipe } from "@angular/common";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { TicketFacade } from "./TicketFacade";
import { TicketViewModel } from "./TicketViewModel";

@Component({
  selector: "app-ticket",
  standalone: true,
  imports: [CurrencyPipe, DatePipe, RouterLink],
  providers: [TicketFacade, TicketViewModel],
  templateUrl: "./ticket.component.html",
  styleUrl: "./ticket.component.css"
})
export class TicketComponent implements OnInit {
  readonly anchoPapel = signal<58 | 80>(58);
  constructor(readonly vm: TicketViewModel, readonly facade: TicketFacade,
    private readonly route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get("id"));
    if (Number.isInteger(id) && id > 0) void this.facade.consultar(id);
    else this.vm.error.set("Error en el sistema.");
  }

  imprimir(): void { window.print(); }

  cambiarPapel(ancho: number): void {
    this.anchoPapel.set(ancho === 80 ? 80 : 58);
  }
}
