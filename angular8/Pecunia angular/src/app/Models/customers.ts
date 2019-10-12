export class Customer{
    id: number;
    customerID: string;
    customerName: string;
    customerMobile: string;
    customerEmail: string;

    constructor(Id: number, custID: string, custName: string, custMobile: string, custEmail: string) {
        this.id = Id;
        this.customerID = custID;
        this.customerName = custName;
        this.customerMobile = custMobile;
        this.customerEmail = custEmail;
        
    }
}
