import { FilialForAdd } from '../Filial/FilialForAdd';

export interface PartnerForRegistration{
    Id: number;
    UserId: number;
    Name: string;
    Category: string;
    Subcategory: string;
    Desciption: string;
    Filial: FilialForAdd;
    Logo: File;
    site: string;
}

