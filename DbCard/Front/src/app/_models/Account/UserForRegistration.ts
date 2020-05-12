import { Role } from './role';

export interface UserForRegistration{
    UserName: string;
    Password: string;
    PasswordConfirm: string;
    Email: string;
    UserType: Role;
}
