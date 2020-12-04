import { Component, OnInit } from '@angular/core';
import { LoginService } from './../login/shared/login.service';
import { Router } from '@angular/router';
import { AppUsers } from './../login/shared/login.model';
import { AdminService } from './../admin/admin.service';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  public appUsers: AppUsers;
  public users:any
  public userList = new Array<AppUsers>();
  constructor(private router: Router,private service: LoginService, private Aservice: AdminService) { }

  async ngOnInit() {

    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.FirstName = user["firstName"]
    this.appUsers.LastName = user["lastName"]

    const users = await this.Aservice.getAllUsers()
    console.log(users)
    this.getUserList()
  }
  onLogout() {
    this.service.logout();
    this.router.navigateByUrl('/login');
  }
  public getUserList = async () => {
    this.users = await this.Aservice.getAllUsers();
    for (let i = 0; i < this.users.length; i++) {
      let user = new AppUsers();
      user.Id = this.users[i].id.toString();
      user.FirstName = this.users[i].firstName;
      user.LastName = this.users[i].lastName;
      user.Active = this.users[i].active;
      console.log(user)
      this.userList.push(user);
    }
  }
}
