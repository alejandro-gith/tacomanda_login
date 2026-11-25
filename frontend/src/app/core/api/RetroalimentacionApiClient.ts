import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

export interface RetroalimentacionDto {
  readonly id: number;
  readonly fechaHora: string;
  readonly calificacion: number;
}

@Injectable({ providedIn: "root" })
export class RetroalimentacionApiClient {
  constructor(private readonly http: HttpClient) { }
  registrar(calificacion: number, comentario: string): Observable<RetroalimentacionDto> {
    return this.http.post<RetroalimentacionDto>(environment.apiUrl + "/retroalimentacion",
      { calificacion, comentario });
  }
}
