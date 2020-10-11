import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
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
const routes: Routes = [
  { path: 'home',             component: HomeComponent },
  { path: 'newsfeed',             component: NewsfeedComponent },
  { path: 'people-nearby',             component: PeopleNearbyComponent },
  { path: 'friends',             component: FriendsComponent },
  { path: 'videos',             component: VideosComponent },
  { path: 'login-register',             component: LoginRegisterComponent },
  { path: 'timeline',             component: TimelineComponent },
  { path: 'timeline-about',             component: TimelineAboutComponent },
  { path: 'timeline-album',             component: TimelineAlbumComponent },
  { path: 'timeline-friends',             component: TimelineFriendsComponent },
  { path: 'chatroom',             component: ChatRoomComponent },
  { path: 'help',             component: HelpComponent },
  { path: 'contact',             component: ContactComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
