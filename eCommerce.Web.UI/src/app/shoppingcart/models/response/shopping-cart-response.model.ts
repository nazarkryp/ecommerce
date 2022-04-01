import { ProductResponse } from 'app/products/models';

export interface ShoppingCartResponse {
    id: string;
    items: ShoppingCartItemResponse[];
    summary: ShoppingCartSummaryResponse;
}

export interface ShoppingCartItemResponse {
    id: string;
    product: ProductResponse;
    quantity: number;
}

export interface ShoppingCartSummaryResponse {
    total: number;
}
