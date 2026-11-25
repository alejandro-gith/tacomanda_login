import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

export interface ResumenCajaDto { readonly totalSistema: number; }
export interface CierreCajaDto {
  readonly id: number;
  readonly fechaHora: string;
  readonly totalSistema: number;
  readonly totalContado: number;
  readonly diferencia: number;
  readonly huboIncidencias: boolean;
  readonly comentarios: string;
}

@Injectable({ providedIn: "root" })
export class CierreCajaApiClient {
  constructor(private readonly http: HttpClient) { }
  consultarResumen(): Observable<ResumenCajaDto> {
    return this.http.get<ResumenCajaDto>(environment.apiUrl + "/cierre-caja/resumen");
  }
  registrar(totalContado: number, huboIncidencias: boolean, comentarios: string): Observable<CierreCajaDto> {
    return this.http.post<CierreCajaDto>(environment.apiUrl + "/cierre-caja",
      { totalContado, huboIncidencias, comentarios });
  }
}
