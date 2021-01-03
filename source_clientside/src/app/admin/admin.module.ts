import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { AppRoutingModule } from '../app-routing.module';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {DialogDeleteComponent} from './dialog-delete/dialog-delete.component'
import {DialogPostDetailComponent} from './dialog-post-detail/dialog-post-detail.component'
@NgModule({
  declarations: [AdminComponent,
  DialogDeleteComponent,
  DialogPostDetailComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    MatButtonModule,
    MatCardModule
  ]
})
export class AdminModule { }
