import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { HomeLoan } from '../Models/homeLoans';
import { CarLoan } from '../Models/carLoans';
import { EduLoan } from '../Models/eduLoans';
import { Customer } from '../Models/customers';


@Injectable({
  providedIn: 'root'
})
export class LoanDataService implements InMemoryDbService {

  constructor()
  {
  }

  createDb() {

    let homeloans = [
        new HomeLoan(1, "38FC80D6-7FCD-49BA-B022-A4DBFB928416", "7BBAA352-D33D-43F5-B2C4-2F926F9BDAA3", 1200000, 10.65, 8878.89, 123, "12/12/2012", "APPLIED", "SERVICE", 10, 98576.33, 2345.55),
        new HomeLoan(2, "248FA04C-01CB-47F0-83B7-A5EF59532970", "42A0A303-1AE7-459C-9C8A-2C5F25D3BC22", 1000000, 10.65, 7658.78, 134, "12/02/2013", "APPLIED", "RETIRED", 23, 78576.33, 5345.55),
        new HomeLoan(3, "B1637A3E-4503-4F91-8C4E-54418A24651E", "24764658-7F3B-4C9D-853B-97152E4EB24B", 1300000, 10.65, 2345.67, 145, "12/11/2015", "APPLIED", "SERVICE", 12, 58576.33, 2545.55)
    ];


    let carloans = [
        new CarLoan(1, "B5B16C32-6287-45A2-92E9-7C74CDEDAD91", "7BBAA352-D33D-43F5-B2C4-2F926F9BDAA3", 1200000, 10.65, 8878.89, 123, "12/12/2012", "APPLIED", "SERVICE", 98576.33, 2345.55, "OTHERS"),
        new CarLoan(2, "15FAF0C3-0CD9-41D2-B205-46B29B6DFCFD", "42A0A303-1AE7-459C-9C8A-2C5F25D3BC22", 1000000, 10.65, 7658.78, 134, "12/02/2013", "APPLIED", "SERVICE", 78576.33, 5345.55, "TWO_WHEELER"),
        new CarLoan(3, "B90B8BC4-0537-46B7-AEF5-694275FFC007", "24764658-7F3B-4C9D-853B-97152E4EB24B", 1300000, 10.65, 2345.67, 145, "12/11/2015", "APPLIED", "SERVICE", 58576.33, 2545.55, "OTHERS")
    ];


    let eduloans = [
        new EduLoan(1, "031B41F7-B003-46F2-82AE-93D500835A27", "7BBAA352-D33D-43F5-B2C4-2F926F9BDAA3", 1200000, 10.65, 8878.89, 123, "12/12/2012", "APPLIED", "UNDERGRADUATE", "abc institute", "ASDFSER", 1),
        new EduLoan(2, "2FBC7455-E697-4D57-9DF3-F5ADA29C86A3", "42A0A303-1AE7-459C-9C8A-2C5F25D3BC22", 1000000, 10.65, 7658.78, 134, "12/02/2013", "APPLIED", "POSTGRADUATE", "ghi institute", "ASDFSERT", 1),
        new EduLoan(3, "A74FB51D-8F06-413A-B515-2C435DD6672F", "24764658-7F3B-4C9D-853B-97152E4EB24B", 1300000, 10.65, 2345.67, 145, "12/11/2015", "APPLIED", "UNDERGRADUATE", "def institute", "ASDFSDRE", 1)
    ];

      let customers = [
          new Customer(1, "7BBAA352-D33D-43F5-B2C4-2F926F9BDAA3", "Customer1", "1236547890", "email@email.com"),
          new Customer(2, "42A0A303-1AE7-459C-9C8A-2C5F25D3BC22", "Customer2", "1236547891", "email3@email.com"),
          new Customer(3, "24764658-7F3B-4C9D-853B-97152E4EB24B", "Customer3", "1236547892", "email2@email.com"),
          new Customer(4, "61AAAAAA-650E-49D5-AAAA-6C40C9218389", "Customer4", "1236547893", "email1@email.com")
      ];
    return { homeloans, carloans, eduloans, customers };
  }
}

