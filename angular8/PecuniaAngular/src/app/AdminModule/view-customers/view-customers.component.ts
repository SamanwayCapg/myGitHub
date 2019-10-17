/**  DEVELOPED BY - AKSHAY TOPLE
 *  DATE OF CREATION - 10/10/2019
 *  VIEW-CUSTOMERS COMPONENT 
 * 
*/




import { Component, OnInit } from '@angular/core';
import { Customer } from '../../Models/customer';
import { CustomersService } from '../../Services/customers.service';
import { PecuniaComponentBase } from '../../pecunia-component';


//DECORATOR
@Component({
  selector: 'app-view-customers',
  templateUrl: './view-customers.component.html',
  styleUrls: ['./view-customers.component.scss']
})
export class ViewCustomersComponent extends PecuniaComponentBase implements OnInit {
  customers: Customer[] = [];
  showCustomersSpinner: boolean = false;
  viewCustomerCheckBoxes: any;
  newCustomerNumber: number = 1;


  //constructor
  constructor(private CustomersService: CustomersService) {
    super();

    this.viewCustomerCheckBoxes = {
      customerName: true,
      customerNumber: true,
      customerID: true,
      id: true,

      customerAddress: true,
      mobile: true,
      email: true,
      aadharNumber: true,
      panNumber: true,
      customerGender: true,
      customerDOB: true,
      createdOn: true,
      lastModifiedOn: true
    };
  }

  ngOnInit() {
    this.showCustomersSpinner = true;
    this.CustomersService.GetAllCustomers().subscribe((response) => {
      this.customers = response;
      this.showCustomersSpinner = false;
      for (var i = 0; i < this.customers.length; i++) {
        this.newCustomerNumber = this.customers[i].customerNumber;
      }
      this.newCustomerNumber += 1;
    }, (error) => {
      console.log(error);
    })
  }

}
