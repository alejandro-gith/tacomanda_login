import { Role } from "./role.model";

export interface Session {
  employeeId: string;
  username: string;
  displayName: string;
  role: Role;
  accessToken: string;
  expiresAt: string;
}
