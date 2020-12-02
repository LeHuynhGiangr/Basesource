import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from '../admin/admin.component';

const routes: Routes = [{
  path: '', children: [
    { path: 'dashboard', component: AdminComponent },
    { path : '', redirectTo : 'dashboard', pathMatch : 'full' }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
