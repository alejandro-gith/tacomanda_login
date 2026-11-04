import { Injectable, inject, signal } from "@angular/core";
import { Router } from "@angular/router";
import { firstValueFrom } from "rxjs";
import { ApiService } from "../../core/tacomanda-api.service";
import { AuthService, homeForRole } from "../../core/auth.service";
import { AvailableUser } from "../../core/available-user.model";
import { SessionStore } from "../../core/session.store";

@Injectable()
export class LoginFacade {
  private readonly api = inject(ApiService);
  private readonly auth = inject(AuthService);
  private readonly store = inject(SessionStore);
  private readonly router = inject(Router);
  readonly users = signal<AvailableUser[]>([]);
  employeeId = "";
  password = "";
  readonly loading = signal(true);
  readonly submitting = signal(false);
  readonly error = signal(false);
  async initialize(): Promise<void> {
    const session = this.store.session();
    if (session && this.store.authenticated()) {
      await this.router.navigateByUrl(homeForRole(session.role));
      return;
    }
    try {
      this.users.set(await firstValueFrom(this.api.users()));
    } catch {
      this.error.set(true);
    } finally {
      this.loading.set(false);
    }
  }
  async submit(): Promise<void> {
    const employeeId = this.employeeId.trim();
    if (!employeeId || !this.password || this.submitting()) return;
    this.error.set(false);
    this.submitting.set(true);
    try {
      await this.auth.login(employeeId, this.password);
    } catch {
      this.error.set(true);
      this.password = "";
    } finally {
      this.submitting.set(false);
    }
  }
}
