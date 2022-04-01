import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';

declare var Wayforpay: any;

@Injectable({
    providedIn: 'root',
})
export class PaymentService {
    private wayforpay: any;

    constructor() {
        this.wayforpay = new Wayforpay();
    }

    public processPayment(payment: any): Observable<PaymentResult> {
        const observable = new Observable<PaymentResult>(
            (subscriber: Subscriber<PaymentResult>) => {
                this.wayforpay.run(
                    payment,
                    (response: any) => {
                        console.log('FUCK');
                        const result = this.createResult('succeed', response);
                        subscriber.next(result);
                        subscriber.complete();
                    },
                    (response: any) => {
                        console.log('FUCK');
                        const result = this.createResult('succeed', response);
                        subscriber.next(result);
                        subscriber.complete();
                    },
                    (response: any) => {
                        console.log('FUCK');
                        const result = this.createResult('succeed', response);
                        subscriber.next(result);
                        subscriber.complete();
                    }
                );
            }
        );

        return observable;
    }

    private createResult(
        state: 'succeed' | 'failed' | 'pending',
        response: any
    ) {
        const result = new PaymentResult(
            state,
            response.card,
            response.cardType,
            response.currency,
            response.issuerBankCountry,
            response.issuerBankName,
            new Date(response.processingDate * 1000),
            response.reason
        );

        return result;
    }
}

export class PaymentResult {
    constructor(
        public state: 'succeed' | 'failed' | 'pending',
        public card: string,
        public cardType: string,
        public currency: string,
        public issuerBankCountry: string,
        public issuerBankName: string,
        public processingDate: Date,
        public reason: string
    ) {}
}
