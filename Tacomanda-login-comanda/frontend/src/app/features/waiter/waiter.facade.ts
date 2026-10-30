import { Injectable, computed, inject, signal } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ApiService } from "../../core/tacomanda-api.service";
import { AuthService } from "../../core/auth.service";
import { Dish } from "../../core/dish.model";
import { Table } from "../../core/restaurant-table.model";
import { SessionStore } from "../../core/session.store";

export interface CartItem {
  dish: Dish;
  quantity: number;
  note: string;
}

@Injectable()
export class WaiterFacade {
  private readonly api = inject(ApiService);
  readonly auth = inject(AuthService);
  readonly store = inject(SessionStore);
  readonly dishes = signal<Dish[]>([]);
  readonly tables = signal<Table[]>([]);
  readonly cart = signal<CartItem[]>([]);
  readonly category = signal("Todos");
  readonly selectedTable = signal("");
  readonly error = signal(false);
  readonly success = signal("");
  readonly sending = signal(false);
  readonly categories = computed(() => [
    "Todos",
    ...new Set(this.dishes().map((x) => x.category)),
  ]);
  readonly visible = computed(() =>
    this.category() === "Todos"
      ? this.dishes()
      : this.dishes().filter((x) => x.category === this.category()),
  );
  readonly count = computed(() =>
    this.cart().reduce((sum, x) => sum + x.quantity, 0),
  );
  readonly total = computed(() =>
    this.cart().reduce((sum, x) => sum + x.quantity * x.dish.price, 0),
  );
  async initialize(): Promise<void> {
    try {
      const [dishes, tables] = await Promise.all([
        firstValueFrom(this.api.dishes(true)),
        firstValueFrom(this.api.tables()),
      ]);
      this.dishes.set(dishes);
      this.tables.set(tables);
    } catch {
      this.error.set(true);
    }
  }
  quantity(id: string): number {
    return this.cart().find((x) => x.dish.id === id)?.quantity ?? 0;
  }
  add(dish: Dish): void {
    const current = this.cart();
    const found = current.find((x) => x.dish.id === dish.id);
    this.cart.set(
      found
        ? current.map((x) =>
            x.dish.id === dish.id ? { ...x, quantity: x.quantity + 1 } : x,
          )
        : [...current, { dish, quantity: 1, note: "" }],
    );
    this.success.set("");
  }
  change(id: string, delta: number): void {
    this.cart.set(
      this.cart()
        .map((x) =>
          x.dish.id === id ? { ...x, quantity: x.quantity + delta } : x,
        )
        .filter((x) => x.quantity > 0),
    );
  }
  note(id: string, note: string): void {
    this.cart.set(
      this.cart().map((x) =>
        x.dish.id === id ? { ...x, note: note.slice(0, 200) } : x,
      ),
    );
  }
  selectTable(id: string): void {
    this.selectedTable.set(id.trim());
  }
  clear(): void {
    this.cart.set([]);
    this.selectedTable.set("");
    this.success.set("");
  }
  async send(): Promise<void> {
    const tableId = this.selectedTable().trim();
    const items = this.cart().map((x) => ({
      dishId: x.dish.id,
      quantity: x.quantity,
      note: x.note.trim(),
    }));
    if (!tableId || items.length === 0 || this.sending()) {
      this.error.set(true);
      return;
    }
    try {
      this.error.set(false);
      this.sending.set(true);
      const order = await firstValueFrom(this.api.createOrder(tableId, items));
      this.success.set(`Comanda #${order.number} enviada a cocina.`);
      this.cart.set([]);
      this.selectedTable.set("");
      this.tables.set(await firstValueFrom(this.api.tables()));
    } catch {
      this.error.set(true);
    } finally {
      this.sending.set(false);
    }
  }
}
