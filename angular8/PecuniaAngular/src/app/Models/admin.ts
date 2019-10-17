/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  ADMIN
 * 
*/


export class Admin {
  id: number;
  adminID: string;
  adminName: string;
  email: string;
  password: string;
  lastModifiedDateTime: string;

  constructor(ID: number, AdminID: string, AdminName: string, Email: string, Password: string, LastModifiedDateTime: string) {
    this.id = ID;
    this.adminID = AdminID;
    this.adminName = AdminName;
    this.email = Email;
    this.password = Password;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


