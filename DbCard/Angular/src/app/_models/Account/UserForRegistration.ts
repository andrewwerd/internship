export interface UserForRegistration{
    UserName: string;
    Password: string;
    PasswordConfirm: string;
    Email: string;
    UserType: UserType;
}
enum UserType{
    Customer,
    Partner
}
