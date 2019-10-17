/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  EMPLOYEE SERVICES
 * 
*/



import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Models/employee';


//decorator
@Injectable({
  providedIn: 'root'
})

  //EmployeesService Class
export class EmployeesService {
  constructor(private httpClient: HttpClient) {
  }


  //add employee service
  AddEmployee(employee: Employee): Observable<boolean> {
    employee.creationDateTime = new Date().toLocaleDateString();
    employee.lastModifiedDateTime = new Date().toLocaleDateString();
    employee.employeeID = this.uuidv4();
    return this.httpClient.post<boolean>(`/api/employees`, employee);
  }


  //update employee service
  UpdateEmployee(employee: Employee): Observable<boolean> {
    employee.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/employees`, employee);
  }


  //delete employee service
  DeleteEmployee(employeeID: string, id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`/api/employees/${id}`);
  }


  //get all employees service
  GetAllEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`/api/employees`);
  }


  //get employee by employee id service
  GetEmployeeByEmployeeID(EmployeeID: string): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`/api/employees?employeeID=${EmployeeID}`);
  }

  //get employee by EmployeeName service
  GetEmployeesByEmployeeName(EmployeeName: string): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`/api/employees?employeeName=${EmployeeName}`);
  }

  //get employee by Email service
  GetEmployeeByEmail(Email: string): Observable<Employee> {
    return this.httpClient.get<Employee>(`/api/employees?email=${Email}`);
  }

  //get employee by Email and Password service
  GetEmployeeByEmailAndPassword(Email: string, Password: string): Observable<Employee> {
    return this.httpClient.get<Employee>(`/api/employees?email=${Email}&password=${Password}`);
  }

  //get employee by Password service
  GetEmployeeByPassword(Password: string): Observable<Employee> {
    return this.httpClient.get<Employee>(`/api/employees?password=${Password}`);
  }

  //get employee by id service
  GetEmployeeByID(ID: number): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`/api/employees?id=${ID}`);
  }

  //change employee password service
  ChangeEmployeePassword(employee: Employee): Observable<boolean> {
    employee.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/employees`, employee);
  }

  uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}



