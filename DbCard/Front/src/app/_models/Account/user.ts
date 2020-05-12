import { Role } from './role';

export interface User{
  id: number;
  role: Role;
  token?: string;
}
