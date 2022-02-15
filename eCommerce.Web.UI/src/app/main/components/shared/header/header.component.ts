import { Component, OnInit } from '@angular/core';

import { AuthenticationService, CurrentUser } from 'app/infrastructure/services';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
    isExpanded = false;

    constructor(private authenticationService: AuthenticationService) {}

    public currentUser: CurrentUser = null!;

    public signIn() {
        this.authenticationService.signIn();
    }

    public signOut() {
        this.authenticationService.signOut();
    }

    public ngOnInit(): void {
        this.authenticationService.currentUser.subscribe(currentUser => {
            this.currentUser = currentUser;
        });
    }
}
