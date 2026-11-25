import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { CrearComandaRequest } from "../modelos/CrearComandaRequest";
import { ComandaDto } from "../modelos/ComandaDto";
import { DetalleComandaInput } from "../modelos/DetalleComandaInput";

@Injectable({ providedIn: "root" })
export class ComandasApiClient {
  constructor(private readonly http: HttpClient) { }

  crear(request: CrearComandaRequest): Observable<ComandaDto> {
    return this.http.post<ComandaDto>(environment.apiUrl + "/comandas", request);
  }

  consultar(estado?: string): Observable<ReadonlyArray<ComandaDto>> {
    return this.http.get<ReadonlyArray<ComandaDto>>(environment.apiUrl + "/comandas",
      { params: estado ? { estado } : {} });
  }

  consultarPorId(id: number): Observable<ComandaDto> {
    return this.http.get<ComandaDto>(environment.apiUrl + "/comandas/" + id);
  }

  editar(id: number, detalles: ReadonlyArray<DetalleComandaInput>): Observable<ComandaDto> {
    return this.http.put<ComandaDto>(environment.apiUrl + "/comandas/" + id, { detalles });
  }

  cambiarEstado(id: number, estado: "EnPreparacion" | "Lista"): Observable<ComandaDto> {
    return this.http.patch<ComandaDto>(environment.apiUrl + "/comandas/" + id + "/estado", { estado });
  }
}
