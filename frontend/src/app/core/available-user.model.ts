import { Role } from "./role.model";

export interface AvailableUser {
  id: string;
  displayName: string;
  role: Role;
}
