import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";
import { Transaction } from 'src/app/Models/transaction';
import { TransactionsService } from 'src/app/Services/transactions.services';
import { PecuniaComponentBase } from 'src/app/pecunia-component';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})

export class TransactionsComponent extends PecuniaComponentBase implements OnInit {
  allTransactions: Transaction[] = [];
  transactionsearch: Transaction[] = [];
  transactions: Transaction[] = [];
  ListOfAllTransactions: boolean = true;
  SearchList: boolean = false;
  showTransactionsSpinner: boolean = false;
  viewTransactionCheckBoxes: any;
  typeOfTransaction: string;

  saveCheque: boolean = false;
  saveSlip: boolean = false;

  newTransactionForm: FormGroup;
  newTransactionForm1: FormGroup;
  newTransactionDisabled: boolean = false;
  newTransactionFormErrorMessages: any;

  newSearchForm: FormGroup;

  newSearchDisabled: boolean = false;
  newSearchFormErrorMessages: any;


  constructor(private transactionsService: TransactionsService) {
    super();
    this.typeOfTransaction = "All";

    this.newTransactionForm = new FormGroup({
      accountNumber: new FormControl(null, [Validators.required, Validators.min(300000), Validators.max(599999), Validators.pattern(/[0-9]/)]),
      typeOfTransaction: new FormControl(null, [Validators.required]),
      amount: new FormControl(null, [Validators.required, Validators.min(0), Validators.max(50000), Validators.pattern(/[0-9]/)]),
      chequeNumber: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(6), Validators.pattern(/[0-9]/)]),
      modeOfTransaction: new FormControl(null, [Validators.required])
    });

    this.newTransactionFormErrorMessages =
      {
        accountNumber: { required: "Account Number can't be blank" },
        typeOfTransaction: { required: "Type of Transaction can't be blank" },
        amount: { required: "Amount can't be blank" },
        chequeNumber: { required: "Cheque Number can't be blank" },
        modeOfTransaction: { required: "Confirm Mode" }
      };

    this.newTransactionForm1 = new FormGroup({
      accountNumber: new FormControl(null, [Validators.required, Validators.min(300000), Validators.max(599999), Validators.pattern(/[0-9]/)]),
      typeOfTransaction: new FormControl(null, [Validators.required]),
      amount: new FormControl(null, [Validators.required, Validators.min(0), Validators.max(50000), Validators.pattern(/[0-9]/)]),
      modeOfTransaction: new FormControl(null, [Validators.required])

    });

    this.newSearchForm = new FormGroup({
      accountnumber: new FormControl(null, [Validators.required])
    })

    this.viewTransactionCheckBoxes =
      {
        accountNumber: true,
        typeOfTransaction: true,
        amount: true,
        dateOfTransaction: true,
        modeOfTransaction: true
      };
  }

  ngOnInit() {
    this.showTransactionsSpinner = true;
    this.transactionsService.GetAllTransactions().subscribe((response) => {
      this.transactions = response;
      this.allTransactions = response;
      console.log(this.transactions);
      this.showTransactionsSpinner = false;
    }, (error) => {
      console.log(error);
    })
  }

  onAddSearchClick() {
    var AccountNumber: number = this.newSearchForm.value.accountnumber;
    console.log(AccountNumber);
    this.transactionsService.GetTransactionByAccountNumber(AccountNumber).subscribe((response) => {

      console.log(response);
      this.transactionsearch = response;
      console.log(response);
      this.ListOfAllTransactions = false;
      this.SearchList = true;

    },
      (error) => {
        console.log(error);
        this.newTransactionDisabled = false;
      });

  }

  onTypeOfTransactionChange() {
    this.transactions = this.allTransactions.filter((transaction: Transaction) => {
      return transaction.typeOfTransaction == this.typeOfTransaction
    });
  }

  onCreateTransactionClick1() {
    this.newTransactionForm1.reset();
    this.newTransactionForm1["submitted"] = false;
  }

  onAddTransactionClick1(event) {
    this.newTransactionForm1["submitted"] = true;
    if (this.newTransactionForm1.valid) {
      this.newTransactionDisabled = true;
      var transaction: Transaction = this.newTransactionForm1.value;

      this.transactionsService.CreateTransaction(transaction).subscribe((addResponse) => {
        this.newTransactionForm1.reset();
        $("#btnAddTransactionCancel1").trigger("click");
        this.newTransactionDisabled = false;
        this.showTransactionsSpinner = true;

        this.transactionsService.GetAllTransactions().subscribe((getResponse) => {
          this.showTransactionsSpinner = false;
          this.transactions = getResponse;
        }, (error) => {
          console.log(error);
        });
      },
        (error) => {
          console.log(error);
          this.newTransactionDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.newTransactionForm1);
    }
  }

  onCreateTransactionClick() {
    this.newTransactionForm.reset();
    this.newTransactionForm["submitted"] = false;
  }


  onAddTransactionClick(event) {
    this.newTransactionForm["submitted"] = true;
    if (this.newTransactionForm.valid) {
      this.newTransactionDisabled = true;
      var transaction: Transaction = this.newTransactionForm.value;

      this.transactionsService.CreateTransaction(transaction).subscribe((addResponse) => {
        this.newTransactionForm.reset();
        $("#btnAddTransactionCancel").trigger("click");
        this.newTransactionDisabled = false;
        this.showTransactionsSpinner = true;

        this.transactionsService.GetAllTransactions().subscribe((getResponse) => {
          this.showTransactionsSpinner = false;
          this.transactions = getResponse;
        }, (error) => {
          console.log(error);
        });
      },
        (error) => {
          console.log(error);
          this.newTransactionDisabled = false;
        });
    }
    else {
      super.getFormGroupErrors(this.newTransactionForm);
    }
  }

  onViewSelectAllClick() {
    for (let propertyName of Object.keys(this.viewTransactionCheckBoxes)) {
      this.viewTransactionCheckBoxes[propertyName] = true;
    }
  }

  onViewDeselectAllClick() {
    for (let propertyName of Object.keys(this.viewTransactionCheckBoxes)) {
      this.viewTransactionCheckBoxes[propertyName] = false;
    }
  }

  getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any {
    return {
      'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
      'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
    };
  }

  getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
    return this.newTransactionFormErrorMessages[formControlName][validationProperty];
  }

  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }


  saveChequeTransaction() {
    this.saveCheque = true;
  }

  saveSlipTransaction() {
    this.saveSlip = true;
  }
}
