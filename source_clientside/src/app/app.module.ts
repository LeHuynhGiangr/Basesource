import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// import { HeaderComponent } from './layout/header/header.component';
// import { HeaderLogoutComponent } from './layout/header-logout/header-logout.component';
// import { FooterComponent } from './layout/footer/footer.component';
// import { NewsfeedComponent } from './newsfeed/newsfeed.component';
// import { InboxComponent } from './inbox/inbox.component';
// import { FanpageComponent } from './fanpage/fanpage.component';
// import { LikersComponent } from './likers/likers.component';
// import { NewpageComponent } from './newpage/newpage.component';
// import { FriendsComponent } from './friends/friends.component';
// import { ImagesComponent } from './images/images.component';
// import { VideosComponent } from './videos/videos.component';
// import { MessagesComponent } from './messages/messages.component';
// import { NotificationsComponent } from './notifications/notifications.component';
// import { PeopleNearbyComponent } from './people-nearby/people-nearby.component';
// import { InsightsComponent } from './insights/insights.component';
// import { LoginComponent } from './login/login.component';
// import { LogoutComponent } from './logout/logout.component';
//import { TimelineComponent } from './main/timeline/timeline.component';
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
// import { WidgetsComponent } from './widgets/widgets.component';
//import { _404Component } from './404/404.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginModule } from './login/login.module';
import { MainModule } from './main/main.module';
import { GeneralModule } from './general/general.module';
import { AdminModule } from './admin/admin.module';
import { _404Module } from './404/404.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    MainModule,
    GeneralModule,
    AdminModule,
    _404Module
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

