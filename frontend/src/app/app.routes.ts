import { Routes } from "@angular/router";
import { InicioSesionComponent } from "./features/inicio-sesion/InicioSesionComponent";
import { CrearComandaComponent } from "./features/crear-comanda/CrearComandaComponent";
import { meseroGuard } from "./core/sesion/mesero.guard";
import { administradorGuard } from "./core/sesion/administrador.guard";
import { AdministracionComponent } from "./features/administracion/AdministracionComponent";

export const routes: Routes = [
  { path: "login", component: InicioSesionComponent },
  { path: "comandas/crear", component: CrearComandaComponent, canActivate: [meseroGuard] },
  { path: "administracion", component: AdministracionComponent, canActivate: [administradorGuard] },
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "**", redirectTo: "login" }
];
