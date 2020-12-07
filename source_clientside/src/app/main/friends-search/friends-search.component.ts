import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { SearchService } from './shared/friends-search.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
    selector: 'app-friends-search',
    templateUrl: './friends-search.component.html',
    styleUrls: ['./friends-search.component.css']
})
export class FriendsSearchComponent implements OnInit {

    public appUsers: AppUsers;
    public users:any
    public userList = new Array<AppUsers>();
    constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService
    ,public uriHandler:UriHandler, public Sservice:SearchService) {}
    async ngOnInit() {
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = "../assets/js/script.js";
        this.elementRef.nativeElement.appendChild(script);
        this.getUserList()
    }
    onLogout() {
        this.service.logout();
        this.router.navigateByUrl('/login');
    }
    public getUserList = async () => {
        this.users = await this.Sservice.getAllUsers();
        for (let i = 0; i < this.users.length; i++) {
          let user = new AppUsers();
          user.Id = this.users[i].id.toString();
          user.FirstName = this.users[i].firstName;
          user.LastName = this.users[i].lastName;
          user.Descriptions = this.users[i].description
          user.Avatar = this.users[i].avatar
          this.userList.push(user);
          console.log(user)
        }
      }
}
