import { NgModule } from '@angular/core';

import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRippleModule } from '@angular/material/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
    imports: [
        MatListModule,
        MatRippleModule,
        MatCheckboxModule,
        MatChipsModule,
        MatIconModule,
        MatButtonModule,
        MatAutocompleteModule,
        MatSnackBarModule,
        MatProgressSpinnerModule,
    ],
    exports: [
        MatListModule,
        MatRippleModule,
        MatCheckboxModule,
        MatChipsModule,
        MatIconModule,
        MatButtonModule,
        MatAutocompleteModule,
        MatSnackBarModule,
        MatProgressSpinnerModule,
    ],
    providers: [],
})
export class AppMaterialModule {}
