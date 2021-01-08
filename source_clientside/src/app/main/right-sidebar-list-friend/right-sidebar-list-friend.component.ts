import { Component, OnInit } from '@angular/core';
import { ChattingService } from 'src/app/_core/services/chatting.service';

@Component({
  selector: 'app-right-sidebar-list-friend',
  templateUrl: './right-sidebar-list-friend.component.html',
  styleUrls: ['./right-sidebar-list-friend.component.css']
})
export class RightSidebarListFriendComponent implements OnInit {
  public m_short_friend_lst:any
  constructor(public m_chattingService:ChattingService) {
    this.loadFriendData();
  }

  ngOnInit(): void {
    this.loadFriendData();
  }
  loadFriendData(){
    this.m_chattingService.getFriendDataById().subscribe(jsonData => {
      this.m_short_friend_lst=jsonData; alert(this.m_short_friend_lst.friendJsonString[0].Id)});
  }
}
