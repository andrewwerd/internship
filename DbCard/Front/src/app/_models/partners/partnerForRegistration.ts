import { Filial } from '../filial/filial';

export interface PartnerForRegistration{
    name: string;
    categoryId: string;
    subcategoryId: string;
    desciption: string;
    filial: Filial;
    site: string;
    birthdayDiscount: number;
    userName: string;
    password: string;
    email: string;
    phoneNumber: string;
}

