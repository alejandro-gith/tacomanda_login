import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { PlatilloDto } from "../modelos/PlatilloDto";

@Injectable({ providedIn: "root" })
export class PlatillosApiClient {
  constructor(private readonly http: HttpClient) { }

  consultar(): Observable<ReadonlyArray<PlatilloDto>> {
    return this.http.get<ReadonlyArray<PlatilloDto>>(environment.apiUrl + "/platillos");
  }

  crear(datos: PlatilloRequest): Observable<PlatilloDto> {
    return this.http.post<PlatilloDto>(environment.apiUrl + "/platillos", datos);
  }

  editar(id: string, datos: PlatilloRequest): Observable<PlatilloDto> {
    return this.http.put<PlatilloDto>(environment.apiUrl + "/platillos/" + id, datos);
  }

  eliminar(id: string): Observable<void> {
    return this.http.delete<void>(environment.apiUrl + "/platillos/" + id);
  }
}

export interface PlatilloRequest {
  nombre: string;
  categoria: string;
  descripcion: string;
  precio: number;
  emoji: string;
}
