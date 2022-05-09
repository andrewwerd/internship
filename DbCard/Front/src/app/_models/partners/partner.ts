import { Category } from '../category';

export interface Partner{
    id: number;
    userId: number;
    name: string;
    category: Category;
    subcategory: Category;
    rating: number;
    description: string;
    site: string;
    isPremium: boolean;
}
