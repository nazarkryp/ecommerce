import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from 'app/infrastructure/services';
import { ShoppingCartService } from 'app/shared/services';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
    constructor(
        private authenticationService: AuthenticationService,
        private shoppingCartService: ShoppingCartService
    ) {}

    public ngOnInit(): void {
        this.authenticationService.trySignIn().subscribe((session) => {});
        this.shoppingCartService.getShoppingCart().subscribe();
    }
}
