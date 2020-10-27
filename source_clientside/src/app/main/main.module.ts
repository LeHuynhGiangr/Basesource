import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';
import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { TimelineComponent } from './timeline/timeline.component';

export const mainRoutes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      //http://doamin/main/
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      //http://doamin/main/home
      { path: 'home', component: NewsfeedComponent },
      //http://doamin/main/home
      { path: 'timeline', component: TimelineComponent },
    ],
  },
];

@NgModule({
  declarations: [MainComponent, NewsfeedComponent, TimelineComponent],
  imports: [CommonModule, RouterModule.forChild(mainRoutes)],
})
export class MainModule {}
