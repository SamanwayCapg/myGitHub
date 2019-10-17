/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  EMPLOYEE COMPONENT 
 * 
*/


import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/employee';
import { EmployeesService } from '../../Services/employees.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";
import { PecuniaComponentBase } from '../../pecunia-component';


//Decorator
@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})

   
//EmployeesComponent Class 
export class EmployeesComponent extends PecuniaComponentBase implements OnInit {
  employees: Employee[] = [];
  showEmployeesSpinner: boolean = false;
  viewEmployeeCheckBoxes: any;
  searchEmployees: Employee[] = [];
  searchEmployeeList: boolean = false;
  employeeList: boolean = true;

  sortBy: string = "employeeName";
  sortDirection: string = "ASC";

  //new Employee Form
  newEmployeeForm: FormGroup;
  newEmployeeDisabled: boolean = false;
  newEmployeeFormErrorMessages: any;

  //edit Employee Form
  editEmployeeForm: FormGroup;
  editEmployeeDisabled: boolean = false;
  editEmployeeFormErrorMessages: any;

  //delete Employee Form
  deleteEmployeeForm: FormGroup;
  deleteEmployeeDisabled: boolean = false;

  searchForm: FormGroup;


  //constructor 
  constructor(private employeeService: EmployeesService) {
    super();
    this.newEmployeeForm = new FormGroup({
      employeeName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      employeeMobile: new FormControl(null, [Validators.required, Validators.pattern(/^[6789]\d{9}$/)]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.pattern(/((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})/)])
    });

    this.newEmployeeFormErrorMessages = {
      employeeName: { required: "Employee Name can't be blank", minlength: "Employee Name should contain at least 2 characters", maxlength: "Employee Name can't be longer than 40 characters" },
      employeeMobile: { required: "Mobile number can't be blank", pattern: "10 digit Mobile number is required" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" },
      password: { required: "Password can't be blank", pattern: "Password should contain should be between 6 to 15 characters long, with at least one uppercase letter, one lowercase letter and one digit" }
    };



    this.editEmployeeForm = new FormGroup({
      id: new FormControl(null),
      employeeID: new FormControl(null),
      employeeName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      employeeMobile: new FormControl(null, [Validators.required, Validators.pattern(/^[6789]\d{9}$/)]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null),
      creationDateTime: new FormControl(null)
    });

    this.editEmployeeFormErrorMessages = {
      employeerName: { required: "Employee Name can't be blank", minlength: "Employee Name should contain at least 2 characters", maxlength: "Employee Name can't be longer than 40 characters" },
      employeeMobile: { required: "Mobile number can't be blank", pattern: "10 digit Mobile number is required" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" }
    };

    this.viewEmployeeCheckBoxes = {
      employeeID: true,
      employeeName: true,
      mobile: true,
      email: true,
      createdOn: true,
      lastModifiedOn: true
    };

    this.deleteEmployeeForm = new FormGroup({
      id: new FormControl(null),
      employeeID: new FormControl(null),
      employeeName: new FormControl(null)
    });


    this.searchForm = new FormGroup({
      employeeID : new FormControl(null)
    });
  }

  ngOnInit() {
    this.showEmployeesSpinner = true;
    this.employeeService.GetAllEmployees().subscribe((response) => {
      this.employees = response;
      this.showEmployeesSpinner = false;
    }, (error) => {
        console.log(error);
      })
  }

  //add employee event
  onCreateEmployeeClick() {
    this.newEmployeeForm.reset();
    this.newEmployeeForm["submitted"] = false;
  }

  onAddEmployeeClick(event) {
    this.newEmployeeForm["submitted"] = true;
    if (this.newEmployeeForm.valid) {
      this.newEmployeeDisabled = true;
      var employee: Employee = this.newEmployeeForm.value;

      this.employeeService.AddEmployee(employee).subscribe((addResponse) => {
        this.newEmployeeForm.reset();
        $("#btnAddEmployeeCancel").trigger("click");
        this.newEmployeeDisabled = false;
        this.showEmployeesSpinner = true;

        this.employeeService.GetAllEmployees().subscribe((getResponse) => {
          this.showEmployeesSpinner = false;
          this.employees = getResponse;
        }, (error) => {
            console.log(error);
          });
      },
        (error) => {
          console.log(error);
          this.newEmployeeDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.newEmployeeForm);
    }
  }



  getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any {
    return {
      'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
      'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
    };
  }

  getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
    return this.newEmployeeFormErrorMessages[formControlName][validationProperty];
  }

  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }


  //edit employee event
  onEditEmployeeClick(index) {
    this.editEmployeeForm.reset();
    this.editEmployeeForm["submitted"] = false;
    this.editEmployeeForm.patchValue({
      id: this.employees[index].id,
      employeeID: this.employees[index].employeeID,
      employeeName: this.employees[index].employeeName,
      employeeMobile: this.employees[index].employeeMobile,
      email: this.employees[index].email,
      password: this.employees[index].password,
      creationDateTime: this.employees[index].creationDateTime
    });
  }

  onUpdateEmployeeClick(event) {
    this.editEmployeeForm["submitted"] = true;
    if (this.editEmployeeForm.valid) {
      this.editEmployeeDisabled = true;
      var employee: Employee = this.editEmployeeForm.value;

      this.employeeService.UpdateEmployee(employee).subscribe((updateResponse) => {
        this.editEmployeeForm.reset();
        $("#btnUpdateEmployeeCancel").trigger("click");
        this.editEmployeeDisabled = false;
        this.showEmployeesSpinner = true;

        this.employeeService.GetAllEmployees().subscribe((getResponse) => {
          this.showEmployeesSpinner = false;
          this.employees = getResponse;
        }, (error) => {
            console.log(error);
          });
      },
        (error) => {
          console.log(error);
          this.editEmployeeDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.editEmployeeForm);
    }
  }


  //delete employee event
  onDeleteEmployeeClick(index) {
    this.deleteEmployeeForm.reset();
    this.deleteEmployeeForm["submitted"] = false;
    this.deleteEmployeeForm.patchValue({
      id: this.employees[index].id,
      employeeID: this.employees[index].employeeID,
      employeeName: this.employees[index].employeeName
    });
  }

  onDeleteEmployeeConfirmClick(event) {
    this.deleteEmployeeForm["submitted"] = true;
    if (this.deleteEmployeeForm.valid) {
      this.deleteEmployeeDisabled = true;
      var employee: Employee = this.deleteEmployeeForm.value;

      this.employeeService.DeleteEmployee(employee.employeeID, employee.id).subscribe((deleteResponse) => {
        this.deleteEmployeeForm.reset();
        $("#btnDeleteEmployeeCancel").trigger("click");
        this.deleteEmployeeDisabled = false;
        this.showEmployeesSpinner = true;

        this.employeeService.GetAllEmployees().subscribe((getResponse) => {
          this.showEmployeesSpinner = false;
          this.employees = getResponse;
        }, (error) => {
            console.log(error);
          });
      },
        (error) => {
          console.log(error);
          this.deleteEmployeeDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.deleteEmployeeForm);
    }
  }


  //select all event
  onViewSelectAllClick() {
    for (let propertyName of Object.keys(this.viewEmployeeCheckBoxes)) {
      this.viewEmployeeCheckBoxes[propertyName] = true;
    }
  }


  //deselect all event
  onViewDeselectAllClick() {
    for (let propertyName of Object.keys(this.viewEmployeeCheckBoxes)) {
      this.viewEmployeeCheckBoxes[propertyName] = false;
    }
  }

  //search employee
  onSearchClick() {
    var employeeid = this.searchForm.value.employeeID;
    this.employeeService.GetEmployeeByEmployeeID(employeeid).subscribe((response) => {
      console.log(response);
      this.searchEmployees = response;
      this.searchEmployeeList = true;
      this.employeeList = false;
    },
      (error) => {
        console.log(error);
      }
    );
  }


  //
  onSearchBackClick() {
    this.searchEmployeeList = false;
    this.employeeList = true;
    this.showEmployeesSpinner = true;
    this.employeeService.GetAllEmployees().subscribe((response) => {
      this.employees = response;
      this.showEmployeesSpinner = false;
    }, (error) => {
      console.log(error);
    })
  }

  //sort event
  onBtnSortClick() {
    console.log(this.sortBy);
    this.employees.sort((a, b) => {
      let comparison = 0;
      let value1 = ((typeof a[this.sortBy]) == 'string') ? a[this.sortBy].toUpperCase() : a[this.sortBy];
      let value2 = ((typeof b[this.sortBy]) == 'string') ? b[this.sortBy].toUpperCase() : b[this.sortBy];

      if (value1 < value2) {
        comparison = -1;
      }
      else if (value1 > value2) {
        comparison = 1;
      }
      if (this.sortDirection == "DESC")
        comparison = comparison * -1;

      console.log(value1, value2, comparison);
      return comparison;
    });

  }


 
}



