import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { CollectionResponse } from 'app/shared/models';
import { ProductResponse } from 'app/products/models';

@Injectable({
    providedIn: 'root',
})
export class ECommerceClient {
    constructor(
        private httpClient: HttpClient,
        @Inject('BASE_URL') private baseAddress: string
    ) {}

    public getProducts(): Observable<CollectionResponse<ProductResponse>> {
        return this.httpClient.get<CollectionResponse<ProductResponse>>(
            this.baseAddress + 'v1/products'
        );
    }

    public createShoppingCart(): Observable<any> {
        return this.httpClient.post(
            this.baseAddress + 'v1/shoppingcarts',
            null
        );
    }

    public getShoppingCart(shoppingCartId: string): Observable<any> {
        return this.httpClient.get(
            this.baseAddress + `v1/shoppingcarts/${shoppingCartId}`
        );
    }

    public addItem(shoppingCartId: string, productId: string): Observable<any> {
        return this.httpClient.post(
            this.baseAddress + `v1/shoppingcarts/${shoppingCartId}/items`,
            {
                productId: productId,
            }
        );
    }

    public createOrder(shoppingCartId: string): Observable<any> {
        return this.httpClient.post(this.baseAddress + 'v1/orders', {
            shoppingCartId: shoppingCartId,
        });
    }

    public getCurrentOrder(): Observable<any> {
        return this.httpClient.get<any>(this.baseAddress + 'v1/orders');
    }

    public getPaymentStatus(orderId: string) {
        return this.httpClient.get<any>(
            this.baseAddress + `v1/payments/${orderId}`
        );
    }

    public createPayment(request: any) {
        return this.httpClient.post<any>('v1/payments', request);
    }
}
