import { Component, OnInit } from '@angular/core';

import { ECommerceClient } from 'app/infrastructure/services';

declare var Wayforpay: any;
declare var CryptoJS: any;

@Component({
    selector: 'app-checkout',
    templateUrl: './checkout.component.html',
    styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit {
    private wayforpay: any;
    private paymentDetails: any;

    constructor(private ecommerceClient: ECommerceClient) {
        this.wayforpay = new Wayforpay();
    }

    public processPayment() {
        this.wayforpay.run(
            this.paymentDetails,
            (response: any) => {
                console.log('SUCCESS');

                this.ecommerceClient
                    .getPaymentStatus(
                        this.paymentDetails.orderReference,
                        this.paymentDetails.merchantSignature
                    )
                    .subscribe((response) => {
                        console.log(response);
                    });
            },
            (error: any) => {
                console.log('ERROR');

                this.ecommerceClient
                    .getPaymentStatus(
                        this.paymentDetails.orderReference,
                        this.paymentDetails.merchantSignature
                    )
                    .subscribe((response) => {
                        console.log(response);
                    });
            },
            (pending: any) => {
                console.log('PENDING');
            }
        );
    }

    public ngOnInit(): void {

        this.ecommerceClient.getCurrentOrder().subscribe((response: any) => {
            this.paymentDetails = response;
            console.log('PAYMENT DETAILS');
            console.log(response);

            console.log(this.wayforpay.getPayUrl());
        });
    }
}
