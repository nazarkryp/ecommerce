import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'app/main/modules';

import * as components from './components';

@NgModule({
    imports: [
        CommonModule,
        AppMaterialModule,
        RouterModule.forChild([
            {
                path: '',
                component: components.ShoppingCartComponent,
                pathMatch: 'full',
            },
        ]),
    ],
    declarations: [components.ShoppingCartComponent],
})
export class ShoppingCartModule {}
