import { CurrencyPipe } from "@angular/common";
import { Component, OnInit, inject } from "@angular/core";
import { WaiterFacade } from "./waiter.facade";

@Component({
  selector: "app-waiter",
  standalone: true,
  imports: [CurrencyPipe],
  providers: [WaiterFacade],
  templateUrl: "./waiter.component.html",
  styleUrl: "./waiter.component.css",
})
export class WaiterComponent implements OnInit {
  readonly f = inject(WaiterFacade);
  async ngOnInit(): Promise<void> {
    await this.f.initialize();
  }
}
