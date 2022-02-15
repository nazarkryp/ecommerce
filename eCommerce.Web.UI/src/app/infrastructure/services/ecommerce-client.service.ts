import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class ECommerceClient {
    constructor(
        private httpClient: HttpClient,
        @Inject('BASE_URL') private baseAddress: string
    ) {}

    public getProducts(): Observable<any[]> {
        return this.httpClient.get<any[]>(this.baseAddress + 'v1/products');
    }

    public createOrder(shoppingCardId: string): Observable<any> {
        return this.httpClient.post(this.baseAddress + 'v1/orders', {
            shoppingCardId: shoppingCardId,
        });
    }

    public getCurrentOrder(): Observable<any> {
        return this.httpClient.get<any>(this.baseAddress + 'v1/orders');
    }

    public getPaymentStatus(paymentReference: string, signature: string) {
        return this.httpClient.get<any>(
            this.baseAddress + `v1/payments/${paymentReference}/${signature}`
        );
    }
}
