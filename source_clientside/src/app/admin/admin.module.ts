import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { AppRoutingModule } from '../app-routing.module';
import {MatButtonModule} from '@angular/material/button';
@NgModule({
  declarations: [AdminComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    MatButtonModule
  ]
})
export class AdminModule { }
