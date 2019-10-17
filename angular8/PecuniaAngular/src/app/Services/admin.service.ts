/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  ADMIN SERVICES
 * 
*/




import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Admin } from '../Models/admin';


//decorator
@Injectable({
  providedIn: 'root'
})

  //AdminService Class
export class AdminService {
  constructor(private httpClient: HttpClient) {

  }


  //update admin details service
  UpdateAdmin(admin: Admin): Observable<boolean> {
    admin.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/admins`, admin);
  }


  //get all admins service
  GetAllAdmins(): Observable<Admin[]> {
    return this.httpClient.get<Admin[]>(`/api/admins`);
  }


  //change admin password service
  ChangeAdminPassword(admin: Admin): Observable<boolean> {
    admin.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/admins`, admin);
  }


  //get admin by admin id service
  GetAdminByAdminID(AdminID: string): Observable<Admin[]> {
    return this.httpClient.get<Admin[]>(`/api/admins?adminID=${AdminID}`);
  }

}
