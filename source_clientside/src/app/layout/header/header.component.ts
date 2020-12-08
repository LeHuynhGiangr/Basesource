import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { UserProfile } from '../../_core/data-repository/profile'
import { SearchService } from '../../main/friends-search/shared/friends-search.service';
@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    public appUsers: AppUsers;
    public NameSearch :string
    public m_returnUrl: string;
    public users:any
    public userList = new Array<AppUsers>();
    constructor(private router: Router ,private service: LoginService, public uriHandler:UriHandler, private m_route: ActivatedRoute, private m_router: Router,
      public Sservice:SearchService) {}

    async ngOnInit() {
      //var user = await this.service.getUser();
      this.appUsers = new AppUsers();
      this.appUsers.Avatar = UserProfile.Avatar
    }
    getPath(){
      return this.router.url;
    }
    onLogout() {
      this.service.logout();
      this.router.navigateByUrl('/login');
    }
    async search(){
      UserProfile.Name = this.NameSearch
      this.users = await this.Sservice.getAllUsers(UserProfile.Name);
        for (let i = 0; i < this.users.length; i++) {
            let user = new AppUsers();
            user.Id = this.users[i].id.toString();
            user.FirstName = this.users[i].firstName;
            user.LastName = this.users[i].lastName;
            user.Descriptions = this.users[i].description
            user.Avatar = this.users[i].avatar
            user.UserName = this.users[i].userName
            if(this.users[i].userName==UserProfile.UserName)
            {
                i=i+1;
            }
            else
            {
                this.userList.push(user);
            }
        }
      this.refresh()
    }
    refresh(): void {
      this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/friends-search';
      this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
      //window.location.reload();
    }
}

