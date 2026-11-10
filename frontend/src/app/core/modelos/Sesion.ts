export interface Sesion {
  readonly empleadoId: string;
  readonly usuario: string;
  readonly nombre: string;
  readonly rol: string;
  readonly accessToken: string;
  readonly expiraEn: string;
}
