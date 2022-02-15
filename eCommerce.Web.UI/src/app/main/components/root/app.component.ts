import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from 'app/infrastructure/services';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
    title = 'app';

    constructor(private authenticationService: AuthenticationService) {}

    public ngOnInit(): void {
        this.authenticationService.trySignIn().subscribe((session) => {});
    }
}
