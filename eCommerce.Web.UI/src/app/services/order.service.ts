import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class OrderService {
    constructor(
        private httpClient: HttpClient,
        @Inject('BASE_URL') private baseAddress: string
    ) {}

    public getCurrentOrder(): Observable<any[]> {
        return this.httpClient.get<any[]>(this.baseAddress + 'v1/orders/current');
    }
}
