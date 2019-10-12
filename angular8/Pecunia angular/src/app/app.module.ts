import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApplyLoanComponent } from './Components/ApplyLoan/applyLoan.component';
import { ShowLoanComponent } from './Components/ShowLoan/showLoan.component';
import { ApplyLoanModule } from './ApplyLoanModule/applyLoan.module';
import { LoanDataService } from './InMemoryWebAPIServices/loan-data.services';
import { environment } from '../environments/environment.prod';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

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
    ApplyLoanModule,
    environment.production ? HttpClientInMemoryWebApiModule.forRoot(LoanDataService, { delay: 1000 }) : [],
  ],

  providers: [],

  bootstrap: [AppComponent]
})
export class AppModule {

}
