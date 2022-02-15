import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { CheckoutComponent } from 'app/checkout/components/checkout/checkout.component';

import * as components from './components';

@NgModule({
    declarations: [components.ProductsComponent],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {
                path: '',
                component: components.ProductsComponent,
                pathMatch: 'full',
            },
            {
                path: ':p/checkout',
                component: CheckoutComponent,
            },
        ]),
    ],
})
export class ProductsModule {}
