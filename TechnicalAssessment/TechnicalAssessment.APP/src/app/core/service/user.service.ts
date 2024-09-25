import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { User } from '../models/user.model';  // Replace with your actual User model
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root',
})
export class UserService extends BaseService<User> {
    constructor(httpClient: HttpClient) {
        super(httpClient, 'user');  // 
    }
}