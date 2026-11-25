import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { ComandaDto } from "../modelos/ComandaDto";

@Injectable({ providedIn: "root" })
export class CobrosApiClient {
  constructor(private readonly http: HttpClient) { }
  cobrar(id: number, formaPago: "Efectivo" | "Tarjeta", monto: number,
    porcentajePropina: number): Observable<ComandaDto> {
    return this.http.post<ComandaDto>(environment.apiUrl + "/comandas/" + id + "/cobro",
      { formaPago, monto, porcentajePropina });
  }
}
