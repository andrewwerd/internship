import { FilialForAdd } from '../filial/filialForAdd';

export interface PartnerForRegistration{
    Id: number;
    UserId: number;
    Name: string;
    Category: string;
    Subcategory: string;
    Desciption: string;
    Filial: FilialForAdd;
    Logo: File;
    Site: string;
}

