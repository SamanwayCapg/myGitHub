import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../Models/customers';

@Injectable({
    providedIn:'root'
})
export class CustomerServices {
    constructor(private httpClient: HttpClient) {

    }

    GetAllCustomers(): Observable<Customer[]> {
        return this.httpClient.get<Customer[]>(`/api/customers`);
    }

}
