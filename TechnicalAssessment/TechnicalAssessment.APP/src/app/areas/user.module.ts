import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';  // Import ReactiveFormsModule
import { UserComponent } from './user.component';  // Adjust path as necessary

@NgModule({
    declarations: [
        UserComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule  // Add ReactiveFormsModule
    ],
    exports: [
        UserComponent
    ]
})
export class UserModule { }