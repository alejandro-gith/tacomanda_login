import { Routes } from "@angular/router";
import { InicioSesionComponent } from "./features/inicio-sesion/InicioSesionComponent";
import { CrearComandaComponent } from "./features/crear-comanda/CrearComandaComponent";
import { meseroGuard } from "./core/sesion/mesero.guard";
import { administradorGuard } from "./core/sesion/administrador.guard";
import { AdministracionComponent } from "./features/administracion/AdministracionComponent";
import { cocineroGuard } from "./core/sesion/cocinero.guard";
import { CambiarEstadoComandaComponent } from "./features/cocina/CambiarEstadoComandaComponent";
import { ConsultarComandasComponent } from "./features/consultar-comandas/ConsultarComandasComponent";
import { cajeroGuard } from "./core/sesion/cajero.guard";
import { cobroGuard } from "./core/sesion/cobro.guard";
import { CajaComponent } from "./features/caja/CajaComponent";
import { TicketComponent } from "./features/ticket/TicketComponent";
import { cierreGuard } from "./core/sesion/cierre.guard";
import { sesionGuard } from "./core/sesion/sesion.guard";
import { CierreCajaComponent } from "./features/cierre-caja/CierreCajaComponent";
import { RetroalimentacionComponent } from "./features/retroalimentacion/RetroalimentacionComponent";

export const routes: Routes = [
  { path: "login", component: InicioSesionComponent },
  { path: "comandas/crear", component: CrearComandaComponent, canActivate: [meseroGuard] },
  { path: "comandas", component: ConsultarComandasComponent, canActivate: [meseroGuard] },
  { path: "caja", component: CajaComponent, canActivate: [cajeroGuard] },
  { path: "ticket/:id", component: TicketComponent, canActivate: [cobroGuard] },
  { path: "cierre-caja", component: CierreCajaComponent, canActivate: [cierreGuard] },
  { path: "retroalimentacion", component: RetroalimentacionComponent, canActivate: [sesionGuard] },
  { path: "cocina", component: CambiarEstadoComandaComponent, canActivate: [cocineroGuard] },
  { path: "administracion", component: AdministracionComponent, canActivate: [administradorGuard] },
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "**", redirectTo: "login" }
];
