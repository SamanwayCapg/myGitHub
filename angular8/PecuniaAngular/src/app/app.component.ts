/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  APP COMPONENT
 * 
*/



import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserAccountService } from './Services/user-account.service';
import { User } from './Models/user';


//decorator
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(public userAccountService: UserAccountService, private router: Router) {
  }

  //on logout click event
  onLogOutClick() {
    this.userAccountService.currentUser = new User(null, null);
    this.userAccountService.isLoggedIn = false;
    this.userAccountService.currentUserType = null;
    this.router.navigate(["/login"]);
  }
}



