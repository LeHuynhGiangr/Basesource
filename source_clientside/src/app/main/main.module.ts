import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';

import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { EditBasicComponent } from './edit-basic/edit-basic.component';
import { EditWorkComponent } from './edit-work/edit-work.component';
import { EditHobbyComponent } from './edit-hobby/edit-hobby.component';
import { EditSettingComponent } from './edit-setting/edit-setting.component';
import { EditPasswordComponent } from './edit-password/edit-password.component';
import { FriendsSearchComponent } from './friends-search/friends-search.component';
import { FriendsComponent } from './friends/friends.component';
import { FanpageComponent } from './fanpage/fanpage.component';
import { FaqComponent } from './faq/faq.component';
import { GroupsComponent } from './groups/groups.component';
import { GroupsSearchComponent } from './groups-search/groups-search.component';

/*start group home */
import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { ListNavigationComponent } from './list-navigation/list-navigation.component';
import { RightSidebarListFriendComponent } from './right-sidebar-list-friend/right-sidebar-list-friend.component';
/**end group home */

import { InboxComponent } from './inbox/inbox.component';
import { ImagesComponent } from './images/images.component';
import { InsightsComponent } from './insights/insights.component';
import { KnowledgeComponent } from './knowledge/knowledge.component';
import { LikersComponent } from './likers/likers.component';
import { MessagesComponent } from './messages/messages.component';
import { NewpageComponent } from './newpage/newpage.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { PeopleNearbyComponent } from './people-nearby/people-nearby.component';
import { TimelineComponent } from './timeline/timeline.component';
import { TripComponent } from './trip/trip.component';
import { VideosComponent } from './videos/videos.component';
import { WidgetsComponent } from './widgets/widgets.component';
import { HeaderComponent } from '../layout/header/header.component';
import { FooterComponent } from '../layout/footer/footer.component';
import { NgxEchartsModule } from 'ngx-echarts';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ItemFriendComponent } from './right-sidebar-list-friend/item-friend/item-friend.component';
import { PostComponent } from './post/post.component';
import { PostMetaComponent } from './post/post-meta/post-meta.component';
import { CommentAreaComponent } from './post/comment-area/comment-area.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DialogPostComponent } from './post/dialog-post/dialog-post.component';
import { MatButtonModule } from '@angular/material/button';
import { TripDialogComponent } from './trip/trip-dialog/trip-dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { AddFriendDialogComponent } from './trip/addfriend-dialog/addfriend-dialog.component';
import { MatListModule } from '@angular/material/list';
import { ChatBoxComponent } from './chat-box/chat-box.component';
export const mainRoutes: Routes = [

  { path: 'home', component: NewsfeedComponent },//main entry point

  /* ------------------------------------------- */
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'edit-basic', component: EditBasicComponent },
  { path: 'edit-hobby', component: EditHobbyComponent },
  { path: 'edit-password', component: EditPasswordComponent },
  { path: 'edit-setting', component: EditSettingComponent },
  { path: 'edit-work', component: EditWorkComponent },
  { path: 'friends', component: FriendsComponent },
  { path: 'friends-search', component: FriendsSearchComponent },
  { path: 'fanpage', component: FanpageComponent },
  { path: 'faq', component: FaqComponent },
  { path: 'groups', component: GroupsComponent },
  { path: 'groups-search', component: GroupsSearchComponent },
  { path: 'inbox', component: InboxComponent },
  { path: 'images', component: ImagesComponent },
  { path: 'insights', component: InsightsComponent },
  { path: 'knowledge', component: KnowledgeComponent },
  { path: 'likers', component: LikersComponent },
  { path: 'messages', component: MessagesComponent },
  { path: 'newpage', component: NewpageComponent },
  { path: 'notifications', component: NotificationsComponent },
  { path: 'people-nearby', component: PeopleNearbyComponent },
  { path: 'trip', component: TripComponent },
  { path: 'timeline/:id', component: TimelineComponent },
  //{ path: 'timeline', component: TimelineComponent },
  { path: 'videos', component: VideosComponent },
  { path: 'widgets', component: WidgetsComponent },
];

@NgModule({
  declarations: [
    MainComponent,
    HeaderComponent,
    FooterComponent,
    AboutComponent,
    ContactComponent,
    EditBasicComponent,
    EditHobbyComponent,
    EditPasswordComponent,
    EditSettingComponent,
    EditWorkComponent,
    FriendsComponent,
    FriendsSearchComponent,
    FanpageComponent,
    FaqComponent,
    GroupsComponent,
    GroupsSearchComponent,
    InboxComponent,
    ImagesComponent,
    InsightsComponent,
    KnowledgeComponent,
    LikersComponent,
    MessagesComponent,
    DialogPostComponent,
    /**start group home */
    NewsfeedComponent,

    /*Post */
    PostComponent,
    PostMetaComponent,
    CommentAreaComponent,
    /**left of page */
    ListNavigationComponent,

    /**right of page */
    /**start RightSidebarListFriendComponent*/
    RightSidebarListFriendComponent,
    ItemFriendComponent,//inside list friend
    /**start RightSidebarListFriendComponent*/
    /**end group home */

    NewpageComponent,
    NotificationsComponent,
    PeopleNearbyComponent,
    TimelineComponent,
    TripComponent,
    TripDialogComponent,
    VideosComponent,
    WidgetsComponent,
    AddFriendDialogComponent,
    ChatBoxComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    MatSelectModule,
    MatListModule,
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts')
    }),
    RouterModule.forChild(mainRoutes),],
})
export class MainModule { }
