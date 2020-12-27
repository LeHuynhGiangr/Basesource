import { Component, OnInit } from '@angular/core';
import { LoginService } from '../_core/services/login.service';
import { ActivatedRoute, Router } from '@angular/router';
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
  public m_returnUrl: string;
  public userList = new Array<AppUsers>();
  constructor(private router: Router,private service: LoginService, private Aservice: AdminService,
    private m_route: ActivatedRoute, private m_router: Router) { }

  async ngOnInit() {

    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.FirstName = user["firstName"]
    this.appUsers.LastName = user["lastName"]
    this.router.routeReuseStrategy.shouldReuseRoute = () =>{
      return false;
    }
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
  deleteUser(id){
    alert("Delete successfully !")
    this.Aservice.deleteUser(id)
    this.refresh()
  }
  blockUser(id){
    alert("Successfully !")
    this.Aservice.blockUser(id)
    this.refresh()
  }
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/admin';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    //window.location.reload();
  }
}
