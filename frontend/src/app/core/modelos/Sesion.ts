export interface Sesion {
  readonly empleadoId: number;
  readonly usuario: string;
  readonly nombre: string;
  readonly rol: string;
  readonly accessToken: string;
  readonly expiraEn: string;
}
