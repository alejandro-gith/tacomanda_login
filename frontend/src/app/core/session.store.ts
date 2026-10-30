import { Injectable, computed, signal } from "@angular/core";
import { Session } from "./session.model";

@Injectable({ providedIn: "root" })
export class SessionStore {
  private readonly key = "tacomanda.session";
  readonly session = signal<Session | null>(this.restore());
  readonly authenticated = computed(() => {
    const value = this.session();
    return !!value && new Date(value.expiresAt).getTime() > Date.now();
  });
  start(value: Session): void {
    localStorage.setItem(this.key, JSON.stringify(value));
    this.session.set(value);
  }
  clear(): void {
    localStorage.removeItem(this.key);
    this.session.set(null);
  }
  private restore(): Session | null {
    try {
      const raw = localStorage.getItem(this.key);
      if (!raw) return null;
      const value = JSON.parse(raw) as Session;
      if (new Date(value.expiresAt).getTime() <= Date.now()) {
        localStorage.removeItem(this.key);
        return null;
      }
      return value;
    } catch (error) {
      console.error("[TacoManda] Invalid stored session", error);
      localStorage.removeItem(this.key);
      return null;
    }
  }
}
