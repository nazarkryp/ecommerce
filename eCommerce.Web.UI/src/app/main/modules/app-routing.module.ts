import { NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';

import {
    Routes,
    RouterModule,
    Router,
    ActivatedRoute,
    PreloadAllModules,
} from '@angular/router';
import { HomeComponent, PageNotFoundComponent } from 'app/main/components';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
    {
        path: 'products',
        loadChildren: () =>
            import('app/products/products.module').then(
                (m) => m.ProductsModule
            ),
    },
    {
        path: '404',
        component: PageNotFoundComponent,
        data: {
            title: 'PhotoCloud - Page Not Found',
        },
    },
    // {
    //     path: ':username',
    //     component: UserMediaComponent,
    //     resolve: {
    //         userMedia: UserMediaResolver
    //     },
    //     data: {
    //         title: 'PhotoCloud - User Posts'
    //     }
    // },
    // {
    //     path: 'p/:mediaId',
    //     component: MediaDetailsComponent,
    //     data: {
    //         title: 'PhotoCloud - Post'
    //     }
    // },
    {
        path: '**',
        redirectTo: '404',
    },
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
    ],
    exports: [RouterModule],
})
export class AppRoutingModule {
    constructor(router: Router, activatedRoute: ActivatedRoute, title: Title) {}
}
