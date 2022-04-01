import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    Resolve,
    RouterStateSnapshot,
} from '@angular/router';

import { ECommerceClient } from 'app/infrastructure/services';

@Injectable()
export class OrderResolver implements Resolve<any> {
    constructor(private ecommerceClient: ECommerceClient) {}

    public resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const shoppingCartId = localStorage.getItem(
            'shopping-cart-id'
        ) as string;

        if (!shoppingCartId) {
            console.log('SHOPPING CART IS MISSING');
            throw new Error('SHOPPING CART IS MISSING');
        }

        return this.ecommerceClient.createOrder(shoppingCartId);
    }
}
