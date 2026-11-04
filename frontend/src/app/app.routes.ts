import { Routes } from "@angular/router";
<<<<<<< HEAD
import { InicioSesionComponent } from "./features/inicio-sesion/InicioSesionComponent";
import { CrearComandaComponent } from "./features/crear-comanda/CrearComandaComponent";
import { meseroGuard } from "./core/sesion/mesero.guard";

export const routes: Routes = [
  { path: "login", component: InicioSesionComponent },
  { path: "comandas/crear", component: CrearComandaComponent, canActivate: [meseroGuard] },
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "**", redirectTo: "login" }
=======
import { authGuard } from "./core/auth.guard";
import { roleGuard } from "./core/role.guard";
import { LoginComponent } from "./features/login/login.component";
import { WaiterComponent } from "./features/waiter/waiter.component";
export const routes: Routes = [
  { path: "login", component: LoginComponent },
  {
    path: "mesero",
    component: WaiterComponent,
    canActivate: [authGuard, roleGuard("Mesero")],
  },
  { path: "", pathMatch: "full", redirectTo: "login" },
  { path: "**", redirectTo: "login" },
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a
];
