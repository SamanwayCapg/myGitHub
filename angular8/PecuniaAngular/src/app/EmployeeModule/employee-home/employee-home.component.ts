/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  EMPLOYEE-HOME COMPONENT 
 * 
*/



import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/employee';
import { EmployeesService } from '../../Services/employees.service';
import { PecuniaComponentBase } from 'src/app/pecunia-component';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserAccountService } from 'src/app/Services/user-account.service';
import * as $ from "jquery";


//Decorator
@Component({
  selector: 'app-employee-home',
  templateUrl: './employee-home.component.html',
  styleUrls: ['./employee-home.component.scss']
})

  //EmployeeHomeComponent Class
export class EmployeeHomeComponent extends PecuniaComponentBase implements OnInit {

  employees: Employee[] = [];
  employee: Employee;
  showEmployeeHomeSpinner: boolean = false;
  viewEmployeeHomeCheckBoxes: any;

  //change password
  changeEmployeePassword: FormGroup;
  changePasswordDisabled: boolean = false;
  changePasswordFormErrorMessages: any;


  //constructor
  constructor(private employeeService: EmployeesService, private userAccountService: UserAccountService) {
    super();


    //this.viewEmployeeHomeCheckBoxes = {
    //  employeeName: true,
    //  mobile: true,
    //  email: true,
    //  createdOn: true,
    //  lastModifiedOn: true,
    //  password: true
    //};

    this.changeEmployeePassword = new FormGroup({
      currentPassword: new FormControl(null, [Validators.required]),
      newPassword: new FormControl(null, [Validators.required, Validators.pattern(/((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})/)]),
      confirmNewPassword: new FormControl(null, [Validators.required])
    });

    this.changePasswordFormErrorMessages = {
      currentPassword: { required: "Current Password cannot be Blank", },
      newPassword: { required: "Password can't be blank", pattern: "Password should contain should be between 6 to 15 characters long, with at least one uppercase letter, one lowercase letter and one digit" },
      confirmNewPassword: { required: "Confirm Password should match with New Password" }
    };

  }

  ngOnInit() {
    this.showEmployeeHomeSpinner = true;
    this.employeeService.GetEmployeeByEmployeeID(this.userAccountService.currentUserID).subscribe((response) => {
      if (response != null && response.length > 0) {
        this.employees = response;
        console.log(this.employees[0].employeeName);
      }
      this.showEmployeeHomeSpinner = false;
      console.log(response.length);
    }, (error) => {
      console.log(error);
    })
  }

  getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any {
    return {
      'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
      'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
    };
  }

  getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
    return this.changePasswordFormErrorMessages[formControlName][validationProperty];
  }

  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }

  //Method for change Password
  onChangeEmployeePasswordClick() {
    this.changeEmployeePassword.reset();
    this.changeEmployeePassword["submitted"] = false;
  }

  onChangePasswordConfirmClick($event) {
    this.changeEmployeePassword["submitted"] = true;
    if (this.changeEmployeePassword.valid) {
      this.changePasswordDisabled = true;
      var newpassword: string = this.changeEmployeePassword.value.newPassword;
      var confirmpassword: string = this.changeEmployeePassword.value.confirmNewPassword;
      var employee: Employee = this.employees[0];
      if (newpassword == confirmpassword) {
        this.employeeService.ChangeEmployeePassword(employee).subscribe((updateResponse) => {
          this.changeEmployeePassword.reset();
          $("#btnChangePasswordCancel").trigger("click");
          this.changePasswordDisabled = false;

          this.employeeService.GetEmployeeByEmployeeID(this.userAccountService.currentUserID).subscribe((getResponse) => {
            this.employees = getResponse;
          }, (error) => {
            console.log(error);
          });
        },
          (error) => {
            console.log(error);
            this.changePasswordDisabled = false;
          });

      }
      else {
        alert('New Password does not Match with Confirm new Password');
        $("#btnChangePasswordCancel").trigger("click");
        this.changePasswordDisabled = false;
      }
    }
    else {
      super.getFormGroupErrors(this.changeEmployeePassword);
    }
  }

}
