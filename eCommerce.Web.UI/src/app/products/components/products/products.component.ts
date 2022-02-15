import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ECommerceClient } from 'app/infrastructure/services';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
    public products: any[] = null!;

    constructor(private eComerceClient: ECommerceClient) {}

    public ngOnInit(): void {
        this.eComerceClient.getProducts().subscribe((products) => {
            this.products = products;
        });
    }
}
