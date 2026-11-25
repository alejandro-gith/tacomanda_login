import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { MesaDto } from "../modelos/MesaDto";

@Injectable({ providedIn: "root" })
export class MesasApiClient {
  constructor(private readonly http: HttpClient) { }

  consultar(): Observable<ReadonlyArray<MesaDto>> {
    return this.http.get<ReadonlyArray<MesaDto>>(environment.apiUrl + "/mesas");
  }
}
