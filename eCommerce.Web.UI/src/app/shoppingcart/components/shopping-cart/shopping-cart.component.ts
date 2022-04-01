import { Component, OnDestroy, OnInit } from '@angular/core';
import { ShoppingCartService } from 'app/shared/services';
import { ShoppingCartResponse } from 'app/shoppingcart/models';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-shopping-cart',
    templateUrl: './shopping-cart.component.html',
    styleUrls: ['./shopping-cart.component.scss'],
})
export class ShoppingCartComponent implements OnInit, OnDestroy {
    private shoppingCartSubscription?: Subscription;
    public shoppingCart?: ShoppingCartResponse;

    constructor(private shoppingCartService: ShoppingCartService) {}

    // LifeCycle Hooks
    public ngOnInit(): void {
        this.shoppingCartSubscription = this.shoppingCartService.ShoppingCart.subscribe((shoppingCart) => {
            this.shoppingCart = shoppingCart;
        });
    }

    public ngOnDestroy(): void {
        if (this.shoppingCartSubscription && !this.shoppingCartSubscription.closed) {
            this.shoppingCartSubscription.unsubscribe();
        }
    }
}
