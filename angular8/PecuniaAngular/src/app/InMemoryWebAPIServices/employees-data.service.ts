/**  DEVELOPED BY - TEAM-F
 *  DATE OF CREATION - 10/10/2019
 *  DATA SERVICES
 * 
*/





import { Injectable } from "@angular/core";
import { InMemoryDbService } from 'angular-in-memory-web-api'
import { Admin } from '../Models/admin';
import { Employee } from '../Models/employee';
import { Transaction } from '../Models/transaction';
import { Customer } from '../Models/customer';
import { EduLoan } from '../Models/eduLoans';
import { CarLoan } from '../Models/carLoans';
import { HomeLoan } from '../Models/homeLoans';



//DECORATOR
@Injectable({
  providedIn: 'root'
})
export class PecuniaDataService implements InMemoryDbService {

  constructor() { }


  //creating database
  createDb() {


    //admins table
    let admins = [
      new Admin(1, '101', 'Admin', 'admin@capgemini.com', 'manager', '10/4/2019')
    ];


    //employees table
    let employees = [
      new Employee(1, "401476EE-0A3B-482E-BD5B-B94A32355959", "Scott", "9876543210", "scott@capgemini.com", "Scott123#", "10/3/2019", "10/4/2019"),
      new Employee(2, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", "Smith", "9988776655", "smith@capgemini.com", "Smith123#", "9/6/2019", "5/7/2019"),
      new Employee(3, "6D68849C-8FA8-4049-A111-B431C76C6548", "Arun", "7781994834", "arun@capgemini.com", "Arun123#", "1/5/2017", "15/11/2018"),
      new Employee(4, "53E8748F-61D6-494B-BF72-E18B27511EFA", "Jones", "6989493491", "jones@capgemini.com", "Jones123#", "2/7/2019", "12/1/2019")
    ];


    //customers table
    let customers = [
      new Customer(1, "401476EE-0A3B-482E-BD5B-B94A32355959", 100001, "Scott", "9876543210", "scott@capgemini.com", "SADHGHGHJKSHD", "825736095581", "10/2/1992", "Male", "ADKPC1022R", "10/3/2019", "10/4/2019"),
      new Customer(2, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", 100002, "Smith", "9988776655", "smith@capgemini.com", "RDSYRWYUEETRU", "823536098851", "23/6/1993", "Male", "RDHKO1099T", "9/6/2019", "5/7/2019"),
      new Customer(3, "6D68849C-8FA8-4049-A111-B431C76C6548", 100003, "Aruni", "7781994834", "aruni@capgemini.com", "SFDYWATEDWDSDJK", "345678904321", "12/7/1997", "Female", "RFTCY4545R", "1/5/2017", "15/11/2018"),
      new Customer(4, "53E8748F-61D6-494B-BF72-E18B27511EFA", 100004, "Jones", "6989493491", "jones@capgemini.com", "FDSGHFGEUFKU", "123456789045", "6/9/1995", "Male", "DRTYU7777N", "2/1/2019", "12/1/2019")
    ];


    //transactions table
    let transactions = [
      new Transaction(1, 404040, "401476EE-0A3B-482E-BD5B-B94A32355959", "Credit", 18400, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", "10/3/2019", "Deposit Slip", ""),

      new Transaction(2, 305640, "6D68849C-8FA8-4049-A111-B431C76C6548", "Debit", 2210, "53E8748F-61D6-494B-BF72-E18B27511EFA", "10/3/2019", "Cheque", "234123"),

      new Transaction(3, 513141, "E9D83ECC-65EE-482A-860C-82A2A4E44F07", "Debit", 12000, "324A20CB-3027-48D7-BFFD-DA3E2AAC77EC", "10/3/2019", "Withdrawal Slip", ""),

      new Transaction(4, 405770, "F7533DB4-3CA5-468F-BAD5-32FC26B4E158", "Credit", 23270, "645BDD67-38D7-4C18-9208-904FBF4E28B4", "10/3/2019", "Cheque", "435812"),

      new Transaction(5, 374040, "501476EE-0A3B-482E-BD5B-B94A32355959", "Debit", 8500, "D628855C-FE7A-4D94-A1BB-167157D3F4EA", "10/3/2019", "Withdrawal Slip", ""),

      new Transaction(6, 563212, "C81476EE-0A3B-482E-BD5B-B94A32355959", "Credit", 1400, "7428855C-FE7A-4D94-A1BB-167157D3F4EA", "10/3/2019", "Deposit Slip", ""),

      new Transaction(7, 342340, "P09476EE-0A3B-482E-BD5B-B94A32355959", "Credit", 1000, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", "10/3/2019", "Deposit Slip", ""),

      new Transaction(8, 475770, "R6533DB4-3CA5-468F-BAD5-32FC26B4E158", "Debit", 3270, "G25BDD67-38D7-4C18-9208-904FBF4E28B4", "10/3/2019", "Cheque", "125812"),

      new Transaction(9, 522790, "30533DB4-3CA5-468F-BAD5-32FC26B4E158", "Credit", 2970, "125BDD67-38D7-4C18-9208-904FBF4E28B4", "10/3/2019", "Cheque", "434412")
    ];


    let homeloans = [
      new HomeLoan(1, "38FC80D6-7FCD-49BA-B022-A4DBFB928416", "401476EE-0A3B-482E-BD5B-B94A32355959", 1200000, 10.65, 8878.89, 123, "12/12/2012", "APPLIED", "SERVICE", 10, 98576.33, 2345.55),
      new HomeLoan(2, "248FA04C-01CB-47F0-83B7-A5EF59532970", "C628855C-FE7A-4D94-A1BB-167157D3F4EA", 1000000, 10.65, 7658.78, 134, "12/02/2013", "APPLIED", "RETIRED", 23, 78576.33, 5345.55),
      new HomeLoan(3, "B1637A3E-4503-4F91-8C4E-54418A24651E", "6D68849C-8FA8-4049-A111-B431C76C6548", 1300000, 10.65, 2345.67, 145, "12/11/2015", "APPLIED", "SERVICE", 12, 58576.33, 2545.55)
    ];


    let carloans = [
      new CarLoan(1, "B5B16C32-6287-45A2-92E9-7C74CDEDAD91", "401476EE-0A3B-482E-BD5B-B94A32355959", 1200000, 10.65, 8878.89, 123, "12/12/2012", "APPLIED", "SERVICE", 98576.33, 2345.55, "OTHERS"),
      new CarLoan(2, "15FAF0C3-0CD9-41D2-B205-46B29B6DFCFD", "C628855C-FE7A-4D94-A1BB-167157D3F4EA", 1000000, 10.65, 7658.78, 134, "12/02/2013", "APPLIED", "SERVICE", 78576.33, 5345.55, "TWO_WHEELER"),
      new CarLoan(3, "B90B8BC4-0537-46B7-AEF5-694275FFC007", "6D68849C-8FA8-4049-A111-B431C76C6548", 1300000, 10.65, 2345.67, 145, "12/11/2015", "APPLIED", "SERVICE", 58576.33, 2545.55, "OTHERS")
    ];


    let eduloans = [
      new EduLoan(1, "031B41F7-B003-46F2-82AE-93D500835A27", "401476EE-0A3B-482E-BD5B-B94A32355959", 1200000, 10.65, 8878.89, 123, "12/12/2012", "APPLIED", "UNDERGRADUATE", "abc institute", "ASDFSER", 1),
      new EduLoan(2, "2FBC7455-E697-4D57-9DF3-F5ADA29C86A3", "C628855C-FE7A-4D94-A1BB-167157D3F4EA", 1000000, 10.65, 7658.78, 134, "12/02/2013", "APPLIED", "POSTGRADUATE", "ghi institute", "ASDFSERT", 1),
      new EduLoan(3, "A74FB51D-8F06-413A-B515-2C435DD6672F", "6D68849C-8FA8-4049-A111-B431C76C6548", 1300000, 10.65, 2345.67, 145, "12/11/2015", "APPLIED", "UNDERGRADUATE", "def institute", "ASDFSDRE", 1)
    ];

    return { admins, employees, customers, transactions, homeloans, carloans, eduloans};
  }

}
