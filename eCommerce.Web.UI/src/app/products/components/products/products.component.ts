import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ECommerceClient } from 'app/infrastructure/services';
import { CollectionResponse } from 'app/shared/models';
import { ProductResponse } from 'app/products/models';
import { ShoppingCartService } from 'app/shared/services';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
    public products: any[] = null!;
    public collectionResponse: CollectionResponse<ProductResponse> = null!;

    constructor(
        private shoppingCartService: ShoppingCartService,
        private eComerceClient: ECommerceClient
    ) {}

    public addToShoppingCart(productId: string) {
        this.shoppingCartService.addItem(productId).subscribe((response) => {

        });
    }

    public ngOnInit(): void {
        this.eComerceClient.getProducts().subscribe((response) => {
            this.collectionResponse = response;
        });
    }
}
