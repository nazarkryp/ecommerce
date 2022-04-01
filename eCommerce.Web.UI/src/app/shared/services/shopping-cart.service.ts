import { Injectable } from '@angular/core';

import { mergeMap, Observable, ReplaySubject, tap } from 'rxjs';

import { ECommerceClient } from 'app/infrastructure/services';
import { ShoppingCartResponse } from 'app/shoppingcart/models';

@Injectable({
    providedIn: 'root',
})
export class ShoppingCartService {
    public readonly ShoppingCart = new ReplaySubject<ShoppingCartResponse>();

    constructor(private ecommerceClient: ECommerceClient) {}

    public addItem(productId: string): Observable<any> {
        let shoppingCartId = localStorage.getItem('shopping-cart-id') as string;

        if (!shoppingCartId) {
            return this.ecommerceClient.createShoppingCart().pipe(
                mergeMap((response: any) => {
                    localStorage.setItem('shopping-cart-id', response.id);
                    shoppingCartId = response.id;

                    return this.ecommerceClient
                        .addItem(response.id, productId)
                        .pipe(
                            mergeMap(() => {
                                return this.ecommerceClient.getShoppingCart(
                                    shoppingCartId
                                );
                            }),
                            tap((shoppingCart) => {
                                this.ShoppingCart.next(shoppingCart);
                            })
                        );
                })
            );
        }

        return this.ecommerceClient.addItem(shoppingCartId, productId).pipe(
            mergeMap(() => {
                return this.ecommerceClient.getShoppingCart(shoppingCartId);
            }),
            tap((shoppingCart) => {
                console.log(shoppingCart);
                this.ShoppingCart.next(shoppingCart);
            })
        );
    }

    public getShoppingCart(): Observable<any> {
        let shoppingCartId = localStorage.getItem('shopping-cart-id') as string;

        return this.ecommerceClient.getShoppingCart(shoppingCartId).pipe(
            tap((shoppingCart) => {
                this.ShoppingCart.next(shoppingCart);
            })
        );
    }
}
