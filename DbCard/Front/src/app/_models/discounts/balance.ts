import {Discount} from './discount';

export class Balance{
    id: number;
    partnerId: number;
    partnerName: string;
    partnerSubcategory: string;
    partnerCategory: string;
    currentAmount: number;
    nextAmount: number;
    discounts: Discount[];
    discountPercent: number;
    accumulationPercent?: number;
    resetDate?: Date;
    isPremium: boolean;
}
