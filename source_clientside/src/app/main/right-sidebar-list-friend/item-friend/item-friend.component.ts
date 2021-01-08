import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-item-friend',
  templateUrl: './item-friend.component.html',
  styleUrls: ['./item-friend.component.css']
})
export class ItemFriendComponent implements OnInit {
  @Input() m_avatarString:string;
  @Input() m_account:string;
  @Input() m_isOnline:boolean=false;

  public short_friend_lst: {
    Id:string,
    Name:string,
    avarThumb:string
  }
  
  constructor() { }

  ngOnInit(): void {
  }

}
