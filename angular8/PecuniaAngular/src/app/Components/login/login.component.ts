/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  LOGIN COMPONENT 
 * 
*/





import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAccountService } from '../../Services/user-account.service';
import { User } from '../../Models/user';


//Decorator
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

  //LoginComponent Class
export class LoginComponent implements OnInit {

  //login form
  loginForm: FormGroup;
  loginFormDisabled: boolean = false;
  loginFormErrorMessages: any;

  loginEmail: boolean = false;
  loginPassword: boolean = false;

  //constructor
  constructor(private userAccountService: UserAccountService, private router: Router) {
    this.loginForm = new FormGroup(
      {
        email: new FormControl(null, [Validators.required, Validators.email]),
        password: new FormControl(null, [Validators.required]),
        userType: new FormControl("admin")
      });

    this.loginFormErrorMessages = {
      email: { required: "Email can't be blank", pattern: "Email is invalid" },
      password: { required: "Password can't be blank"}
      //userType: { required: "User Type should be selected" }
    };
  }

  ngOnInit() {
  }

  getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any {
    return {
      'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
      'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
    };
  }

  getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
    return this.loginFormErrorMessages[formControlName][validationProperty];
  }
  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }

  //adminTabclick event
  onAdminClick() {
    this.loginForm.reset();
    this.loginForm.patchValue({ "userType": 'admin' });
  }

  //employeeTabClick event
  onEmployeeClick() {
    this.loginForm.reset();
    this.loginForm.patchValue({ "userType": 'employee' });
  }

  //login event
  onLoginClick() {
    this.userAccountService.authenticate(this.loginForm.value.email, this.loginForm.value.password, this.loginForm.value.userType).subscribe((response) => {
      if (response != null && response.length > 0) {


        if (this.loginForm.value.userType == "admin") {
          this.userAccountService.currentUser = new User(this.loginForm.value.email, response[0].adminName);
          this.userAccountService.currentUserType = "Admin";
          this.userAccountService.currentUserID = response[0].adminID;
          this.userAccountService.userID = response[0].id;
          this.userAccountService.isLoggedIn = true;
          this.router.navigate(["/admin", "home"]);
        }
        else if (this.loginForm.value.userType == "employee")  {
          this.userAccountService.currentUser = new User(this.loginForm.value.email, response[0].employeeName);
          this.userAccountService.currentUserType = "Employee";
          this.userAccountService.currentUserID = response[0].employeeID;
          this.userAccountService.userID = response[0].id;
          this.userAccountService.isLoggedIn = true;
          this.router.navigate(["/employee", "home"]);
        }

      }
      else {
        alert("Incorrect Email or Password. ");
      }
    }, (error) => {
      console.log(error);
      });

  }


  onChangeEmail() {
    this.loginEmail = true;
  }
 

  onChangePassword() {
    this.loginPassword = true;
  }
}



