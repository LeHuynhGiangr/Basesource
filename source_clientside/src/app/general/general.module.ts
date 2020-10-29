import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralComponent } from './general.component';
import { RouterModule, Routes } from '@angular/router';


export const mainRoutes: Routes = [
  {path: '', redirectTo:'contact',pathMatch:'full'},
];

@NgModule({
  declarations: [
    GeneralComponent, 

  ],
  imports: [CommonModule, RouterModule.forChild(mainRoutes)],
})
export class GeneralModule {}
 