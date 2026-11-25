import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Sesion } from "../modelos/Sesion";

export interface UsuarioDisponibleDto {
  readonly id: number;
  readonly usuario: string;
  readonly nombre: string;
  readonly rol: string;
}

@Injectable({ providedIn: "root" })
export class AuthApiClient {
  constructor(private readonly http: HttpClient) { }

  consultarUsuarios(): Observable<ReadonlyArray<UsuarioDisponibleDto>> {
    return this.http.get<ReadonlyArray<UsuarioDisponibleDto>>(environment.apiUrl + "/auth/users");
  }

  iniciarSesion(usuario: string, password: string): Observable<Sesion> {
    return this.http.post<Sesion>(environment.apiUrl + "/auth/login", { usuario, password });
  }
}
