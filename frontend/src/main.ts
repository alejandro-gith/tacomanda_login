import { bootstrapApplication } from "@angular/platform-browser";
import { AppComponent } from "./app/app.component";
import { appConfig } from "./app/app.config";

function registrarErrorInicial(error: unknown): void {
  console.error("No se pudo iniciar Angular.", error);
}

bootstrapApplication(AppComponent, appConfig).catch(registrarErrorInicial);
