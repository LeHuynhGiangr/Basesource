import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
//http://domain/login/
export const routes: Routes = [
  //
  { path: '', component: LoginComponent },
];

@NgModule({
  declarations: [LoginComponent],
  imports: [CommonModule,HttpClientModule,
    FormsModule, RouterModule.forChild(routes)],
})
export class LoginModule {}
