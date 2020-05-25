import { Category } from '../category';

export interface PartnerGridRow{
    id: number;
    name: string;
    rating: number;
    category: Category;
    subcategory: Category;
    isPremium: boolean;
    isFavoite: boolean;
}
