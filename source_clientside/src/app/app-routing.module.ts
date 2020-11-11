import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenGuard } from './_helpers/authen.guard';
//Global declare routing declaration
const routes: Routes = [
  { path: '', redirectTo: 'main', pathMatch: 'full'},

  //http://domain/main
  { path: 'main', loadChildren: './main/main.module#MainModule', canActivate: [AuthenGuard]}, //call ./main/main.module

  { path: '404', loadChildren: './404/404.module#_404Module' }, //call ./login/login.module

  //http://domain/login
  { path: 'login', loadChildren: './login/login.module#LoginModule' }, //call ./login/login.module

  //http://domain/admin
  { path: 'admin', loadChildren: './admin/admin.module#AdminModule' }, //call ./admin/admin.module

  //http://domain/admin
  { path: 'general', loadChildren: './general/general.module#GeneralModule' }, //call ./general/general.module

  
  {path:'**', redirectTo:'404'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
 