import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { CrearComandaRequest } from "../modelos/CrearComandaRequest";
import { ComandaDto } from "../modelos/ComandaDto";

@Injectable({ providedIn: "root" })
export class ComandasApiClient {
  constructor(private readonly http: HttpClient) { }

  crear(request: CrearComandaRequest): Observable<ComandaDto> {
    return this.http.post<ComandaDto>(environment.apiUrl + "/comandas", request);
  }
}
