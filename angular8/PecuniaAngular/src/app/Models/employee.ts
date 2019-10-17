/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  EMPLOYEE
 * 
*/



export class Employee {
  id: number;
  employeeID: string;
  employeeName: string;
  employeeMobile: string;
  email: string;
  password: string;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(ID: number, EmployeeID: string, EmployeeName: string, EmployeeMobile: string, Email: string, Password: string, CreationDateTime: string, LastModifiedDateTime: string) {
    this.id = ID;
    this.employeeID = EmployeeID;
    this.employeeName = EmployeeName;
    this.employeeMobile = EmployeeMobile;
    this.email = Email;
    this.password = Password;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


