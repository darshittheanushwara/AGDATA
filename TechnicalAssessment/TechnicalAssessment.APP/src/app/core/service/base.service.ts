import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';  // Import environment

@Injectable({
    providedIn: 'root',
})
export class BaseService<T> {

    // API URL
    private readonly REST_API: string = environment.apiUrl;  // Use the global API URL

    // Http Header
    private readonly httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

    constructor(private httpClient: HttpClient, @Inject('apiEndpoint') private apiEndpoint: string) { }

    // Add
    add(data: T): Observable<any> {
        const API_URL = `${this.REST_API}/${this.apiEndpoint}`;
        return this.httpClient.post(API_URL, data, { headers: this.httpHeaders })
            .pipe(catchError(this.handleError));
    }

    // Get all objects
    getAll(): Observable<T[]> {
        const API_URL = `http://127.0.0.1:5000/api/user`;
        return this.httpClient.get<T[]>(API_URL, { headers: this.httpHeaders })
            .pipe(catchError(this.handleError));
    }

    // Get single object
    getById(id: any): Observable<T> {
        const API_URL = `${this.REST_API}/${this.apiEndpoint}/${id}`;
        return this.httpClient.get<T>(API_URL, { headers: this.httpHeaders })
            .pipe(
                map((res: any) => res || {} as T),
                catchError(this.handleError)
            );
    }

    // Update
    update(data: T): Observable<any> {
        const API_URL = `${this.REST_API}/${this.apiEndpoint}`;
        return this.httpClient.put(API_URL, data, { headers: this.httpHeaders })
            .pipe(catchError(this.handleError));
    }

    // Delete
    delete(id: any): Observable<any> {
        const API_URL = `${this.REST_API}/${this.apiEndpoint}/${id}`;
        return this.httpClient.delete(API_URL, { headers: this.httpHeaders })
            .pipe(catchError(this.handleError));
    }

    // Error handling
    private handleError(error: HttpErrorResponse) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Handle client error
            errorMessage = error.error.message;
        } else {
            // Handle server error
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.error(errorMessage);
        return throwError(() => new Error(errorMessage));
    }
}