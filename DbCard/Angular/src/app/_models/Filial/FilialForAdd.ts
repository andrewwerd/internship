import {Schedule} from 'src/app/_models/Filial/Schedule';

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
