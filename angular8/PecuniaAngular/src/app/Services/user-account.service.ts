import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService {
  currentUser: User;
  isLoggedIn: boolean;
  currentUserType: string;
  currentUserID: string;
  userID: number;

  constructor(private httpClient: HttpClient) {
    this.currentUser = new User(null, null);
    this.isLoggedIn = false;
    this.currentUserType = null;
    this.currentUserID = null;
    this.userID = null;
  }

  authenticate(email: string, password: string, userType: string): Observable<any> {
    //return this.httpClient.get(`/api/admins?email=${email}&password=${password}`);
    if (userType == "admin")
      return this.httpClient.get(`/api/admins?password=${password}`);
    else if (userType == "employee")
      return this.httpClient.get(`/api/employees?password=${password}`);
  }

  
}



