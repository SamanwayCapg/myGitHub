import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';



@Component({
  selector: 'show-loan',
  templateUrl: './showLoan.component.html',
  styleUrls: ['./showLoan.component.scss']
})
export class ShowLoanComponent {

    searchBoxForm: FormGroup;
    searchBoxErrorMsg: any;

    constructor() {
        console.log("constructor");

        this.searchBoxForm = new FormGroup({
            selectID: new FormControl(null),
            inputID: new FormControl(null, [Validators.minLength(40),  Validators.required])
        })

        this.searchBoxErrorMsg = {
            inputID: { minLength:"ID length 40",   required:"ID is required"}
        };
    }

    getFormControlStatus(formControlName: string, validationProperty: string, formGroupName: FormGroup): boolean {
        return (formGroupName.get(formControlName).touched &&
            formGroupName.get(formControlName).invalid &&
            formGroupName.get(formControlName).errors[validationProperty]);

    }

    getFormGroupStatus(formGroupName: FormGroup) {
        return formGroupName.valid;
    }

    getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
        return this.searchBoxErrorMsg[formControlName][validationProperty];
    }
    public onChangeSearchBy(event):void {
        const val = event.target.value;
        console.log("here:"+val);
        
    }
}

