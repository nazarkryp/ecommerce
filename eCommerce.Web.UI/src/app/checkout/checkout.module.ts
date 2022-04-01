import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'app/main/modules';

import * as components from './components';
import { OrderResolver } from './resolvers';

@NgModule({
    imports: [
        CommonModule,
        AppMaterialModule,
        RouterModule.forChild([
            {
                path: 'checkout',
                component: components.CheckoutComponent,
                resolve: { order: OrderResolver },
            },
        ]),
    ],
    providers: [OrderResolver],
    declarations: [components.CheckoutComponent],
})
export class CheckoutModule {}
