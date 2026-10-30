import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import { AvailableUser } from "./available-user.model";
import { Dish } from "./dish.model";
import { Order } from "./order.model";
import { Table } from "./restaurant-table.model";
import { Session } from "./session.model";

@Injectable({ providedIn: "root" })
export class ApiService {
  private readonly http = inject(HttpClient);
  private readonly url = environment.apiUrl;
  users(): Observable<AvailableUser[]> {
    return this.http.get<AvailableUser[]>(`${this.url}/auth/users`);
  }
  login(employeeId: string, password: string): Observable<Session> {
    return this.http.post<Session>(`${this.url}/auth/login`, {
      employeeId,
      password,
    });
  }
  dishes(activeOnly = true): Observable<Dish[]> {
    return this.http.get<Dish[]>(`${this.url}/dishes`, {
      params: { activeOnly },
    });
  }
  tables(): Observable<Table[]> {
    return this.http.get<Table[]>(`${this.url}/tables`);
  }
  createOrder(
    tableId: string,
    items: { dishId: string; quantity: number; note: string }[],
  ): Observable<Order> {
    return this.http.post<Order>(`${this.url}/orders`, { tableId, items });
  }
}
