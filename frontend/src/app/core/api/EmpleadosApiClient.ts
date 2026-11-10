import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

export interface AltaEmpleadoRequest {
  usuario: string;
  nombre: string;
  password: string;
  rol: "Mesero" | "Cajero";
}

export interface EmpleadoDto {
  readonly id: string;
  readonly usuario: string;
  readonly nombre: string;
  readonly rol: string;
}

@Injectable({ providedIn: "root" })
export class EmpleadosApiClient {
  constructor(private readonly http: HttpClient) { }

  alta(datos: AltaEmpleadoRequest): Observable<EmpleadoDto> {
    return this.http.post<EmpleadoDto>(environment.apiUrl + "/empleados", datos);
  }
}
