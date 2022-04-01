import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import {
    AuthenticationService,
    CurrentUser,
    ECommerceClient,
} from 'app/infrastructure/services';
import { ShoppingCartService } from 'app/shared/services';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
    isExpanded = false;

    public shoppingCart: any = null!;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private ecommerceClient: ECommerceClient,
        private shoppingCartService: ShoppingCartService
    ) {}

    public currentUser: CurrentUser = null!;

    public signIn() {
        this.authenticationService.signIn();
    }

    public signOut() {
        this.authenticationService.signOut();
    }

    public checkout() {
        this.ecommerceClient
            .createOrder(this.shoppingCart.id)
            .subscribe((orderResponse) => {
                console.log(orderResponse);
                this.router.navigate([orderResponse.orderId, 'checkout']);
            });
    }

    public ngOnInit(): void {
        this.shoppingCartService.ShoppingCart.subscribe((shoppingCart) => {
            this.shoppingCart = shoppingCart;
        });

        this.authenticationService.currentUser.subscribe((currentUser) => {
            this.currentUser = currentUser;
        });
    }
}
