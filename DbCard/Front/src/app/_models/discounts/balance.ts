import {Discount} from './discount';
import { Category } from '../category';

export class Balance{
    id: number;
    partnerId: number;
    partnerName: string;
    subcategory: Category;
    category: Category;
    currentAmount: number;
    nextAmount: number;
    discounts: Discount[];
    discountPercent: number;
    accumulationPercent?: number;
    resetDate?: Date;
    isPremium: boolean;
}
