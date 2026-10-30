import { Component, OnInit, inject } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { LoginFacade } from "./login.facade";

@Component({
  selector: "app-login",
  standalone: true,
  imports: [FormsModule],
  providers: [LoginFacade],
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.css",
})
export class LoginComponent implements OnInit {
  readonly f = inject(LoginFacade);
  async ngOnInit(): Promise<void> {
    await this.f.initialize();
  }
}
