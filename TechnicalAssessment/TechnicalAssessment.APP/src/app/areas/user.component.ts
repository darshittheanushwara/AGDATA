import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../core/service/user.service';  // Adjust path as necessary
import { User } from '../core/models/user.model';  // Adjust path as necessary
import { Observable, BehaviorSubject } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
    userForm: FormGroup;
    userList$: Observable<User[]>;  // Observable for user list
    selectedUser$: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);  // BehaviorSubject to handle selected user
    error: string = '';
    isEditMode: boolean = false; // To track if the form is in "Update" mode


    constructor(private snackBar: MatSnackBar, private fb: FormBuilder, private userService: UserService) {
        this.userForm = this.fb.group({
            id: [''],
            name: ['', Validators.required],
            address: ['']
        });

        this.userList$ = this.userService.getAll();
    }

    ngOnInit(): void {
        // Load users and handle potential errors
        this.userList$.subscribe({
            next: () => { },
            error: error => this.error = 'Error loading users: ' + error
        });


    }

    selectUser(user: User): void {
        this.isEditMode = true;
        this.selectedUser$.next(user);
        this.userForm.patchValue(user);
    }

    createUser(): void {
        if (this.userForm.valid) {
            this.userService.add(this.userForm.value).subscribe({
                next: () => {
                    this.resetForm();
                    this.reloadUsers();
                    this.snackBar.open('User created successfully!', '', { duration: 3000 });

                },
                error: error => {
                    this.error = 'Error creating user: ' + error;
                    this.snackBar.open(this.error, '', { duration: 3000 });
                }
            });
        }
    }

    updateUser(): void {
        if (this.userForm.valid) {
            this.userService.update(this.userForm.value).subscribe({
                next: () => {
                    this.resetForm();
                    this.reloadUsers();
                    this.snackBar.open('User updated successfully!', '', { duration: 3000 });
                },
                error: error => {
                    this.error = 'Error updating user: ' + error;
                    this.snackBar.open(this.error, '', { duration: 3000 });
                }
            });
        }
    }

    deleteUser(id: string | undefined): void {
        if (confirm('Are you sure you want to delete this user?')) {
            this.userService.delete(id).subscribe({
                next: () => {
                    this.reloadUsers()
                    this.snackBar.open('User deleted successfully!', '', { duration: 3000 });
                },

                error: error => {
                    this.error = 'Error deleting user: ' + error
                    this.snackBar.open('Error deleting user: ' + error, '', { duration: 3000 });
                }
            });
        }
    }

    private resetForm(): void {
        this.userForm.reset();
        this.selectedUser$.next(null);
        this.isEditMode = false;

    }

    private reloadUsers(): void {
        this.userList$ = this.userService.getAll();  // Reload users
    }

    private getMockUsers(): any[] {
        return [
            { id: 1, username: 'mockuser1', email: 'mock1@example.com' },
            { id: 2, username: 'mockuser2', email: 'mock2@example.com' },
            { id: 3, username: 'mockuser3', email: 'mock3@example.com' }
        ];
    }
}