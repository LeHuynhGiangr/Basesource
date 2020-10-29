import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import { NewsfeedComponent } from './newsfeed/newsfeed.component';
// import { InboxComponent } from './inbox/inbox.component';
// import { FanpageComponent } from './fanpage/fanpage.component';
// import { LikersComponent } from './likers/likers.component';
// import { NewpageComponent } from './newpage/newpage.component';
// import { FriendsComponent } from './friends/friends.component';
// import { VideosComponent } from './videos/videos.component';
// import { ImagesComponent } from './images/images.component';
// import { MessagesComponent } from './messages/messages.component';
// import { NotificationsComponent } from './notifications/notifications.component';
// import { PeopleNearbyComponent } from './people-nearby/people-nearby.component';
// import { InsightsComponent } from './insights/insights.component';
// import { LoginComponent } from './login/login.component';
// import { LogoutComponent } from './logout/logout.component';
// import { TimelineComponent } from './timeline/timeline.component';
// import { GroupsComponent } from './groups/groups.component';
// import { GroupsSearchComponent } from './groups-search/groups-search.component';
// import { AboutComponent } from './about/about.component';
// import { EditBasicComponent } from './edit-basic/edit-basic.component';
// import { EditWorkComponent } from './edit-work/edit-work.component';
// import { EditHobbyComponent } from './edit-hobby/edit-hobby.component';
// import { EditSettingComponent } from './edit-setting/edit-setting.component';
// import { EditPasswordComponent } from './edit-password/edit-password.component';
// import { ContactComponent } from './contact/contact.component';
// import { FaqComponent } from './faq/faq.component';
// import { KnowledgeComponent } from './knowledge/knowledge.component';
// mport { WidgetsComponent } from './widgets/widgets.component';
// import { _404Component } from './404/404.component';

//Global declare routing declaration
const routes: Routes = [
  //http://domain/
  { path: '', redirectTo: 'login', pathMatch: 'full' },

  { path: '404', loadChildren: './404/404.module#_404Module' }, //call ./login/login.module
  //http://domain/login
  { path: 'login', loadChildren: './login/login.module#LoginModule' }, //call ./login/login.module

  //http://domain/main
  { path: 'main', loadChildren: './main/main.module#MainModule' }, //call ./main/main.module

  //http://domain/admin
  { path: 'admin', loadChildren: './admin/admin.module#AdminModule' }, //call ./admin/admin.module

  //http://domain/admin
  { path: 'general', loadChildren: './general/general.module#GeneralModule' }, //call ./general/general.module

  // { path: 'newsfeed',             component: NewsfeedComponent },
  // { path: 'inbox',             component: InboxComponent },
  // { path: 'fanpage',             component: FanpageComponent },
  // { path: 'likers',             component: LikersComponent },
  // { path: 'newpage',             component: NewpageComponent },
  // { path: 'friends',             component: FriendsComponent },
  // { path: 'images',             component: ImagesComponent },
  // { path: 'videos',             component: VideosComponent },
  // { path: 'messages',             component: MessagesComponent },
  // { path: 'notifications',             component: NotificationsComponent },
  // { path: 'people-nearby',             component: PeopleNearbyComponent },
  // { path: 'insights',             component: InsightsComponent },
  // { path: 'login',             component: LoginComponent },
  // { path: 'logout',             component: LogoutComponent },
  // { path: 'timeline',             component: TimelineComponent },
  // { path: 'groups',             component: GroupsComponent },
  // { path: 'groups-search',             component: GroupsSearchComponent },
  // { path: 'about',             component: AboutComponent },
  // { path: 'edit-basic',             component: EditBasicComponent },
  // { path: 'edit-work',             component: EditWorkComponent },
  // { path: 'edit-hobby',             component: EditHobbyComponent },
  // { path: 'edit-setting',             component: EditSettingComponent },
  // { path: 'edit-password',             component: EditPasswordComponent },
  // { path: 'contact',             component: ContactComponent },
  // { path: 'faq',             component: FaqComponent },
  // { path: 'knowledge',             component: KnowledgeComponent },
  // { path: 'widgets',             component: WidgetsComponent },
  // { path: '404',             component: _404Component },
  // { path: '', redirectTo: 'newsfeed', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
 