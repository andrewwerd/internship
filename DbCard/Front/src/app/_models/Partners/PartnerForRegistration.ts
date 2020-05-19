import { FilialForAdd } from '../filial/filialForAdd';

export interface PartnerForRegistration{
    name: string;
    categoryId: string;
    subcategoryId: string;
    desciption: string;
    filial: FilialForAdd;
    site: string;
    birthdayDiscount: number;
    userName: string;
    password: string;
    email: string;
    phoneNumber: string;
}

