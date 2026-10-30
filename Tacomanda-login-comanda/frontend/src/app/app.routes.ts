import { Routes } from "@angular/router";
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
];
