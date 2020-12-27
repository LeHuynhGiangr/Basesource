import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from '../../../login/shared/login.model';
import { LoginService } from '../../../_core/services/login.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FriendService } from '../../../_core/services/friends.service';
import { UserProfile } from '../../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
    selector: 'app-addfriend-dialog',
    templateUrl: './addfriend-dialog.component.html',
    styleUrls: ['./addfriend-dialog.component.css']
  })
  export class AddFriendDialogComponent implements OnInit {
    public appUsers: AppUsers;
    public users:any
    public userList = new Array<AppUsers>();
    constructor(public dialogRef: MatDialogRef<AddFriendDialogComponent>,private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
      private service: LoginService, private FService:FriendService,public uriHandler:UriHandler) {
  
    }
    async ngOnInit() {
      const friends = await this.getUserList()
    }
    onSave(){

    }
    onNoClick(): void {
        this.dialogRef.close();
    }
    getUserList = async () => {
      console.log(UserProfile.Id)
      this.users = await this.FService.getAllFriends();
      for (let i = 0; i < this.users.length; i++) {
          let user = new AppUsers();
          user.Id = this.users[i].id.toString();
          user.FirstName = this.users[i].firstName;
          user.LastName = this.users[i].lastName;
          user.Descriptions = this.users[i].description
          user.Avatar = this.users[i].avatar
          if(this.users[i].id==UserProfile.Id)
          {
              console.log("trung roi")
          }
          else
          {
              this.userList.push(user);
          }
      }
    }
}