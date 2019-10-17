export class Customer {
  id: number;
  customerID: string;
  customerNumber: number;
  customerName: string;
  customerMobile: string;
  customerAddress: string;
  email: string;
  aadharNumber: string;
  customerDOB: string;
  customerGender: string;
  panNumber: string;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(ID: number, CustomerID: string, CustomerNumber: number, CustomerName: string, CustomerMobile: string, Email: string, CustomerAddress: string, AadharNumber: string, CustomerDOB: string, CustomerGender: string, PANNumber: string, CreationDateTime: string, LastModifiedDateTime: string) {
    this.id = ID;
    this.customerID = CustomerID;
    this.customerNumber = CustomerNumber;
    this.customerName = CustomerName;
    this.customerMobile = CustomerMobile;
    this.email = Email;
    this.panNumber = PANNumber;
    this.aadharNumber = AadharNumber;
    this.customerAddress = CustomerAddress;
    this.customerDOB = CustomerDOB;
    this.customerGender = CustomerGender;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


