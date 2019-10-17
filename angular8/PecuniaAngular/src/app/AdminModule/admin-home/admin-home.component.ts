/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  ADMIN-HOME COMPONENT 
 * 
*/


import { Component, OnInit } from '@angular/core';
import { Admin } from '../../Models/admin';
import { AdminService } from '../../Services/admin.service';
import { PecuniaComponentBase } from 'src/app/pecunia-component';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserAccountService } from 'src/app/Services/user-account.service';
import * as $ from "jquery";



//Decorator
@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss']
})

  //AdminHomeComponent Class
export class AdminHomeComponent extends PecuniaComponentBase implements OnInit {

  admins: Admin[] = [];
  showAdminSpinner: boolean = false;
  viewAdminCheckBoxes: any;

  //edit Admin 
  editAdminForm: FormGroup;
  editAdminDisabled: boolean = false;
  editAdminFormErrorMessages: any;

  //change Admin Password
  changeAdminPassword: FormGroup;
  changePasswordDisabled: boolean = false;
  changePasswordFormErrorMessages: any;

  newAdminFormErrorMessages: any;

  //constructor 
  constructor(private adminService: AdminService, private userAccountService: UserAccountService) {
    super();


    this.newAdminFormErrorMessages = {
      adminName: { required: "Admin Name can't be blank", minlength: "Admin Name should contain at least 2 characters", maxlength: "Admin Name can't be longer than 40 characters" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" }
    };

    this.editAdminForm = new FormGroup({
      id: new FormControl(2),
      adminID: new FormControl(null),
      adminName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null)
    });

    this.editAdminFormErrorMessages = {
      adminName: { required: "Admin Name can't be blank", minlength: "Admin Name should contain at least 2 characters", maxlength: "Employee Name can't be longer than 40 characters" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" }
    };

    this.changeAdminPassword = new FormGroup({
      currentPassword: new FormControl(null, [Validators.required]),
      newPassword: new FormControl(null, [Validators.required, Validators.pattern(/((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})/)]),
      confirmNewPassword: new FormControl(null, [Validators.required])
    });

    this.changePasswordFormErrorMessages = {
      currentPassword: { required: "Current Password cannot be Blank", },
      newPassword: { required: "Password can't be blank", pattern: "Password should contain should be between 6 to 15 characters long, with at least one uppercase letter, one lowercase letter and one digit" },
      confirmNewPassword: { required: "Confirm Password should match with New Password" }
    };

    this.viewAdminCheckBoxes = {
      adminID: true,
      adminName: true,
      email: true,
      lastModifiedOn: true
    };

  }

  ngOnInit() {
    this.showAdminSpinner = true;
    this.adminService.GetAllAdmins().subscribe((response) => {
      this.admins = response;
      this.showAdminSpinner = false;
      console.log(response);
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
    return this.newAdminFormErrorMessages[formControlName][validationProperty];
  }

  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }


  //edit admin event 
  onEditAdminClick(index) {
    this.editAdminForm.reset();
    this.editAdminForm["submitted"] = false;
    this.editAdminForm.patchValue({
      id: this.admins[index].id,
      adminID: this.admins[index].adminID,
      adminName: this.admins[index].adminName,
      email: this.admins[index].email,
      password: this.admins[index].password
    });
  }

  //update admin event
  onUpdateAdminClick(event) {
    this.editAdminForm["submitted"] = true;
    if (this.editAdminForm.valid) {
      this.editAdminDisabled = true;
      var admin: Admin = this.editAdminForm.value;
      console.log(admin);
      this.adminService.UpdateAdmin(admin).subscribe((updateResponse) => {
        this.editAdminForm.reset();
        $("#btnUpdateEmployeeCancel").trigger("click");
        this.editAdminDisabled = false;
        this.showAdminSpinner = true;

        this.adminService.GetAllAdmins().subscribe((getResponse) => {
          this.showAdminSpinner = false;
          this.admins = getResponse;
        }, (error) => {
          console.log(error);
        });
      },
        (error) => {
          console.log(error);
          this.editAdminDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.editAdminForm);
    }
  }


  //Method for change Password
  onChangePasswordClick() {
    this.changeAdminPassword.reset();
    this.changeAdminPassword["submitted"] = false;
  }

  onChangePasswordConfirmClick($event) {
    this.changeAdminPassword["submitted"] = true;
    if (this.changeAdminPassword.valid) {
      this.changePasswordDisabled = true;
      var newpassword: string = this.changeAdminPassword.value.newPassword;
      var confirmpassword: string = this.changeAdminPassword.value.confirmNewPassword;
      var admin: Admin = this.admins[0];
      if (newpassword == confirmpassword) {
        this.adminService.ChangeAdminPassword(admin).subscribe((updateResponse) => {
          this.changeAdminPassword.reset();
          $("#btnChangePasswordCancel").trigger("click");
          this.changePasswordDisabled = false;

          this.adminService.GetAdminByAdminID(this.userAccountService.currentUserID).subscribe((getResponse) => {
            this.admins = getResponse;
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
      super.getFormGroupErrors(this.changeAdminPassword);
    }
  }


}


