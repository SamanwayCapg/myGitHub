import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApplyLoanComponent } from './Components/ApplyLoan/applyLoan.component';
import { ShowLoanComponent } from './Components/ShowLoan/showLoan.component';
import { ApplyLoanModule } from './ApplyLoanModule/applyLoan.module';

@NgModule({
  declarations: [
    AppComponent,
    ApplyLoanComponent,
    ShowLoanComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ApplyLoanModule
  ],

  providers: [],

  bootstrap: [AppComponent]
})
export class AppModule {

}
