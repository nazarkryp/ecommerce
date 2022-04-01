import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PaymentService } from 'app/checkout/services';

import { ECommerceClient } from 'app/infrastructure/services';
import { ShoppingCartService } from 'app/shared/services';
import { ShoppingCartResponse } from 'app/shoppingcart/models';
import { mergeMap } from 'rxjs';

declare var Wayforpay: any;

@Component({
    selector: 'app-checkout',
    templateUrl: './checkout.component.html',
    styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit, OnDestroy {
    private wayforpay: any;
    public shoppingCart?: ShoppingCartResponse;
    public order?: any;

    public b: boolean = true;

    constructor(
        private route: ActivatedRoute,
        private paymentService: PaymentService,
        private ecommerceClient: ECommerceClient,
        private shoppingCartService: ShoppingCartService
    ) {
        this.wayforpay = new Wayforpay();
    }

    public startPayment() {
        const request = {
            orderId: this.order.orderId,
            firstName: 'Nazarii',
            lastName: 'Krypiak',
            emailAddress: 'nazarkryp@gmail.com',
            phoneNumber: '380685293558',
        };

        this.ecommerceClient
            .createPayment(request)
            .pipe(
                mergeMap((paymentRequest: any) => {
                    return this.paymentService.processPayment(paymentRequest);
                })
            )
            .subscribe((response) => {});
    }

    public ngOnInit(): void {
        this.order = this.route.snapshot.data.order;

        this.shoppingCartService.ShoppingCart.subscribe((shoppingCart) => {
            this.shoppingCart = shoppingCart;
        }).unsubscribe();
    }

    public ngOnDestroy(): void {}
}
