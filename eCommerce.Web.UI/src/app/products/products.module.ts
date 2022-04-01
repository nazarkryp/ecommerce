import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import * as components from './components';
import { AppMaterialModule } from 'app/main/modules';

@NgModule({
    imports: [
        CommonModule,
        AppMaterialModule,
        RouterModule.forChild([
            {
                path: '',
                component: components.ProductsComponent,
                pathMatch: 'full',
            },
        ]),
    ],
    declarations: [
        components.ProductsComponent,
        components.CategoriesComponent,
    ],
})
export class ProductsModule {}
