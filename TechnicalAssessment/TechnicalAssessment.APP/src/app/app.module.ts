import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';  // Import ReactiveFormsModule for forms
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule for HTTP requests

import { AppComponent } from './app.component';
import { UserModule } from './areas/user.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  // Import UserModule
import { MatSnackBarModule } from '@angular/material/snack-bar';


@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        UserModule,
        MatSnackBarModule,
        BrowserAnimationsModule  // Include UserModule here
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
