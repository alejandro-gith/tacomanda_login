import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Sesion } from "../modelos/Sesion";

@Injectable({ providedIn: "root" })
export class AuthApiClient {
  constructor(private readonly http: HttpClient) { }

  iniciarSesion(usuario: string, password: string): Observable<Sesion> {
    return this.http.post<Sesion>(environment.apiUrl + "/auth/login", { usuario, password });
  }
}
