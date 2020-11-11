import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';

import { AboutComponent } from './about/about.component';
import { EditBasicComponent } from './edit-basic/edit-basic.component';
import { EditWorkComponent } from './edit-work/edit-work.component';
import { EditHobbyComponent } from './edit-hobby/edit-hobby.component';
import { EditSettingComponent } from './edit-setting/edit-setting.component';
import { EditPasswordComponent } from './edit-password/edit-password.component';
import { FriendsComponent } from './friends/friends.component';
import { FanpageComponent } from './fanpage/fanpage.component';
import { GroupsComponent } from './groups/groups.component';
import { GroupsSearchComponent } from './groups-search/groups-search.component';
import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { InboxComponent } from './inbox/inbox.component';
import { ImagesComponent } from './images/images.component';
import { InsightsComponent } from './insights/insights.component';
import { LikersComponent } from './likers/likers.component';
import { MessagesComponent } from './messages/messages.component';
import { NewpageComponent } from './newpage/newpage.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { PeopleNearbyComponent } from './people-nearby/people-nearby.component';
import { TimelineComponent } from './timeline/timeline.component';
import { VideosComponent } from './videos/videos.component';
import { HeaderComponent } from '../layout/header/header.component';
import { FooterComponent } from '../layout/footer/footer.component';
import { NgxEchartsModule } from 'ngx-echarts';

export const mainRoutes: Routes = [
  {path: '', redirectTo:'home',pathMatch:'full'},
  {path:'about', component:AboutComponent},
  {path:'edit-basic', component:EditBasicComponent},
  {path:'edit-hobby', component:EditHobbyComponent},
  {path:'edit-password', component:EditPasswordComponent},
  {path:'edit-setting', component:EditSettingComponent},
  {path:'edit-work', component:EditWorkComponent},
  {path:'friends', component:FriendsComponent},
  {path:'fanpage', component:FanpageComponent},
  {path:'groups', component:GroupsComponent},
  {path:'groups-search', component:GroupsSearchComponent},
  {path:'home', component:NewsfeedComponent},
  {path:'inbox', component:InboxComponent},
  {path:'images', component:ImagesComponent},
  {path:'insights', component:InsightsComponent},
  {path:'likers', component:LikersComponent},
  {path:'messages', component:MessagesComponent},
  {path:'newpage', component:NewpageComponent},
  {path:'notifications', component:NotificationsComponent},
  {path:'people-nearby', component:PeopleNearbyComponent},
  {path:'timeline', component:TimelineComponent},
  {path:'videos', component:VideosComponent},
];

@NgModule({
  declarations: [
    MainComponent, 
    HeaderComponent,
    FooterComponent,
    AboutComponent,
    EditBasicComponent,
    EditHobbyComponent,
    EditPasswordComponent,
    EditSettingComponent,
    EditWorkComponent,
    FriendsComponent,
    FanpageComponent,
    GroupsComponent,
    GroupsSearchComponent,
    InboxComponent,
    ImagesComponent,
    InsightsComponent,
    LikersComponent,
    MessagesComponent,
    NewsfeedComponent,
    NewpageComponent,
    NotificationsComponent,
    PeopleNearbyComponent,
    TimelineComponent,
    VideosComponent
  ],
  imports: [CommonModule, RouterModule.forChild(mainRoutes),NgxEchartsModule.forRoot({
    echarts: () => import('echarts')
  }),],
})
export class MainModule {}
 