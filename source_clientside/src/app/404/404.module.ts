import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { _404Component } from './404.component';

//http://domain/login/
export const routes: Routes = [
  //
  { path: '', component: _404Component },
];

@NgModule({
  declarations: [_404Component],
  imports: [CommonModule, RouterModule.forChild(routes)],
})
export class _404Module {}
