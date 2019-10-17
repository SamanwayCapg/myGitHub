/**  DEVELOPED BY - AKSHAY TOPLE
 *  DATE OF CREATION - 10/10/2019
 *  CUSTOMERS COMPONENT 
 * 
*/




import { Component, OnInit } from '@angular/core';
import { Customer } from '../../Models/customer';
import { CustomersService } from '../../Services/customers.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";
import { PecuniaComponentBase } from '../../pecunia-component';


//Decorator
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})

  //CustomersComponent Class
export class CustomersComponent extends PecuniaComponentBase implements OnInit {
  customers: Customer[] = [];
  showCustomersSpinner: boolean = false;
  viewCustomerCheckBoxes: any;
  newCustomerNumber: number = 1;

  sortBy: string = "CustomerName";
  sortDirection: string = "ASC";

  newCustomerForm: FormGroup;
  newCustomerDisabled: boolean = false;
  newCustomerFormErrorMessages: any;

  editCustomerForm: FormGroup;
  editCustomerDisabled: boolean = false;
  editCustomerFormErrorMessages: any;

  //constructor
  constructor(private CustomersService: CustomersService) {
    super();
    this.newCustomerForm = new FormGroup({
      customerName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      //CustomerNumber: new FormControl(null),
      customerMobile: new FormControl(null, [Validators.required, Validators.pattern(/^[6789]\d{9}$/)]),
      email: new FormControl(null, [Validators.required, Validators.email]),

    });

    this.newCustomerFormErrorMessages = {
      customerName: { required: "Customer Name can't be blank", minlength: "Customer Name should contain at least 2 characters", maxlength: "Customer Name can't be longer than 40 characters" },
      customerMobile: { required: "Mobile number can't be blank", pattern: "10 digit Mobile number is required" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" },

    };


    //edit customer
    this.editCustomerForm = new FormGroup({
      id: new FormControl(null),
      customerID: new FormControl(null),
      customerName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      customerMobile: new FormControl(null, [Validators.required, Validators.pattern(/^[6789]\d{9}$/)]),
      customerAddress: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(200)]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      //password: new FormControl(null),
      creationDateTime: new FormControl(null)
    });

    this.editCustomerFormErrorMessages = {
      customerName: { required: "Customer Name can't be blank", minlength: "Customer Name should contain at least 2 characters", maxlength: "Customer Name can't be longer than 40 characters" },
      customerAddress: { required: "Customer Address can't be blank", minlength: "Customer Address should contain at least 2 characters", maxlength: "Customer Address can't be longer than 200 characters" },
      customerMobile: { required: "Mobile number can't be blank", pattern: "10 digit Mobile number is required" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" }
    };


    //view customer
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


  //create customer
  onCreateCustomerClick() {
    this.newCustomerForm.reset();
    this.newCustomerForm["submitted"] = false;
  }

  onAddCustomerClick(event) {
    this.newCustomerForm["submitted"] = true;
    if (this.newCustomerForm.valid) {
      this.newCustomerDisabled = true;
      var Customer: Customer = this.newCustomerForm.value;

      this.CustomersService.AddCustomer(Customer, this.newCustomerNumber).subscribe((addResponse) => {
        this.newCustomerForm.reset();
        $("#btnAddCustomerCancel").trigger("click");
        this.newCustomerDisabled = false;
        this.showCustomersSpinner = true;
        this.newCustomerNumber += 1;
        this.CustomersService.GetAllCustomers().subscribe((getResponse) => {
          this.showCustomersSpinner = false;
          this.customers = getResponse;
        }, (error) => {
            console.log(error);
          });
      },
        (error) => {
          console.log(error);
          this.newCustomerDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.newCustomerForm);
    }
  }



  getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any {
    return {
      'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
      'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
    };
  }

  getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
    return this.newCustomerFormErrorMessages[formControlName][validationProperty];
  }

  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }


  //update customer details
  onEditCustomerClick(index) {
    this.editCustomerForm.reset();
    this.editCustomerForm["submitted"] = false;
    this.editCustomerForm.patchValue({
      id: this.customers[index].id,
      // customerID: this.customers[index].customerID,
      //customerNumber: this.customers[index].customerNumber,
      customerName: this.customers[index].customerName,
      customerAddress: this.customers[index].customerAddress,
      customerMobile: this.customers[index].customerMobile,
      email: this.customers[index].email,
      // panNumber: this.customers[index].panNumber,
      // aadharNumber: this.customers[index].aadharNumber,

      creationDateTime: this.customers[index].creationDateTime
    });
  }

  onUpdateCustomerClick(event) {
    this.editCustomerForm["submitted"] = true;
    if (this.editCustomerForm.valid) {
      this.editCustomerDisabled = true;


      var Customer: Customer = this.editCustomerForm.value;

      this.CustomersService.UpdateCustomer(Customer).subscribe((updateResponse) => {
        this.editCustomerForm.reset();
        $("#btnUpdateCustomerCancel").trigger("click");
        this.editCustomerDisabled = false;
        this.showCustomersSpinner = true;

        this.CustomersService.GetAllCustomers().subscribe((getResponse) => {
          this.showCustomersSpinner = false;
          this.customers = getResponse;
        }, (error) => {
            console.log(error);
          });
      },
        (error) => {
          console.log(error);
          this.editCustomerDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.editCustomerForm);
    }
  }







  onViewSelectAllClick() {
    for (let propertyName of Object.keys(this.viewCustomerCheckBoxes)) {
      this.viewCustomerCheckBoxes[propertyName] = true;
    }
  }

  onViewDeselectAllClick() {
    for (let propertyName of Object.keys(this.viewCustomerCheckBoxes)) {
      this.viewCustomerCheckBoxes[propertyName] = false;
    }
  }


  //sort
  onBtnSortClick() {
    console.log(this.sortBy);
    this.customers.sort((a, b) => {
      let comparison = 0;
      let value1 = ((typeof a[this.sortBy]) == 'string') ? a[this.sortBy].toUpperCase() : a[this.sortBy];
      let value2 = ((typeof b[this.sortBy]) == 'string') ? b[this.sortBy].toUpperCase() : b[this.sortBy];
      console.log(this.sortBy);
      //
      if (this.sortBy == "creationDateTime" || this.sortBy == "lastModifiedDateTime") {
        var tt = value1.split("/");
        var d1 = new Date(tt[2], tt[1], tt[0]);
        tt = value2.split("/");
        var d2 = new Date(tt[2], tt[1], tt[0]);
        if (d2 > d1) comparison = -1;
        else comparison = 1;
      }
      else {
        if (value1 < value2) {
          comparison = -1;
        }
        else if (value1 > value2) {
          comparison = 1;
        }
      }
      if (this.sortDirection == "DESC")
        comparison = comparison * -1;

      console.log(value1, value2, comparison);
      return comparison;
    });

  }
}



