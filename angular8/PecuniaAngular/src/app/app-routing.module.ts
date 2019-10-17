/**  DEVELOPED BY - TEAM F - PECUNIA
 *  DATE OF CREATION - 10/10/2019
 *  APP - ROUTING MODULE
 * 
*/


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { AboutComponent } from './Components/about/about.component';


//routes
const routes: Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "login", component: LoginComponent },
  { path: "about", component: AboutComponent },
  { path: "admin", loadChildren: () => import("./AdminModule/admin.module").then(m => m.AdminModule) },
  { path: "employee", loadChildren: () => import("./EmployeeModule/employee.module").then(m => m.EmployeeModule) },
  { path: "**", redirectTo: '/login', pathMatch: 'full' },
];


//decorator, import, export routes
@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }


