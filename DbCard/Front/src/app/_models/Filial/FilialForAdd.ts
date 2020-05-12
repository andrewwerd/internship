import {Schedule} from 'src/app/_models/filial/schedule';

export interface FilialForAdd
{
    Region: string;
    City: string;
    Street: string;
    HouseNumber: string;
    PhoneNumber: string;
    Schedule: Schedule;
    IsMainOffice: boolean;
    PartnerId: number;
}
