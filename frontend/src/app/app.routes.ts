import { Routes } from "@angular/router";
import { InicioSesionComponent } from "./features/inicio-sesion/InicioSesionComponent";
import { CrearComandaComponent } from "./features/crear-comanda/CrearComandaComponent";
import { meseroGuard } from "./core/sesion/mesero.guard";

export const routes: Routes = [
  { path: "login", component: InicioSesionComponent },
  { path: "comandas/crear", component: CrearComandaComponent, canActivate: [meseroGuard] },
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "**", redirectTo: "login" }
];
