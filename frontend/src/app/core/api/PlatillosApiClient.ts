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
}
