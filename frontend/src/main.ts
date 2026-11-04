import { bootstrapApplication } from "@angular/platform-browser";
import { AppComponent } from "./app/app.component";
import { appConfig } from "./app/app.config";
<<<<<<< HEAD

function registrarErrorInicial(error: unknown): void {
  console.error("No se pudo iniciar Angular.", error);
}

bootstrapApplication(AppComponent, appConfig).catch(registrarErrorInicial);
=======
bootstrapApplication(AppComponent, appConfig).catch((error) =>
  console.error("[TacoManda] Bootstrap error", error),
);
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a
