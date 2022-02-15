import { Component, Inject, OnInit } from '@angular/core';

import { ECommerceClient } from '../infrastructure/communication/ecommerce-proxy.service';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent implements OnInit {
    public products: Product[] = [];

    constructor(private proxy: ECommerceClient) {
    }

    public ngOnInit(): void {
        this.proxy.getProducts().subscribe(response => {
            this.products = response;
            console.log(response);
        });
    }
}

interface Product {
    name: string;
    price: number;
}
