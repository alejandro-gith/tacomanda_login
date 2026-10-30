import { Injectable, inject } from "@angular/core";
import { Router } from "@angular/router";
import { firstValueFrom } from "rxjs";
import { ApiService } from "./tacomanda-api.service";
import { Role } from "./role.model";
import { SessionStore } from "./session.store";

@Injectable({ providedIn: "root" })
export class AuthService {
  private readonly api = inject(ApiService);
  private readonly store = inject(SessionStore);
  private readonly router = inject(Router);
  async login(employeeId: string, password: string): Promise<void> {
    const session = await firstValueFrom(this.api.login(employeeId, password));
    this.store.start(session);
    await this.router.navigateByUrl(homeForRole(session.role));
  }
  async logout(): Promise<void> {
    this.store.clear();
    await this.router.navigateByUrl("/login");
  }
}
export function homeForRole(role: Role): string {
  return role === "Mesero" ? "/mesero" : "/login";
}
