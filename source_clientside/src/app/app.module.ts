import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { BannerComponent } from './layout/banner/banner.component';
import { HomeComponent } from './home/home.component';
import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { PeopleNearbyComponent } from './people-nearby/people-nearby.component';
import { FriendsComponent } from './friends/friends.component';
import { VideosComponent } from './videos/videos.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { TimelineComponent } from './timeline/timeline.component';
import { TimelineAboutComponent } from './timeline-about/timeline-about.component';
import { TimelineAlbumComponent } from './timeline-album/timeline-album.component';
import { TimelineFriendsComponent } from './timeline-friends/timeline-friends.component';
import { ChatRoomComponent } from './chatroom/chatroom.component';
import { HelpComponent } from './help/help.component';
import { ContactComponent } from './contact/contact.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    BannerComponent,
    HeaderComponent,
    NewsfeedComponent,
    PeopleNearbyComponent,
    FriendsComponent,
    VideosComponent,
    LoginRegisterComponent,
    TimelineComponent,
    TimelineAboutComponent,
    TimelineAlbumComponent,
    TimelineFriendsComponent,
    ChatRoomComponent,
    HelpComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
