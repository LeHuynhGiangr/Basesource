import { Component, OnInit } from '@angular/core';
import { LoginService } from '../_core/services/login.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AppUsers } from './../login/shared/login.model';
import { AdminService } from './../admin/admin.service';
import {DialogDeleteComponent} from './dialog-delete/dialog-delete.component'
import {DialogPostDetailComponent} from './dialog-post-detail/dialog-post-detail.component'
import { MatDialog } from '@angular/material/dialog';
import { PostService } from 'src/app/_core/services/post.service';
import { Post } from 'src/app/_core/models/Post';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  public m_posts:Post[];
  public appUsers: AppUsers;
  public users:any
  public m_returnUrl: string;
  public userList = new Array<AppUsers>();
  constructor(private router: Router,private service: LoginService, private Aservice: AdminService,
    private m_route: ActivatedRoute, private m_router: Router, public dialog: MatDialog, private PService:PostService) { }

  async ngOnInit() {

    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.FirstName = user["firstName"]
    this.appUsers.LastName = user["lastName"]
    this.router.routeReuseStrategy.shouldReuseRoute = () =>{
      return false;
    }
    this.getUserList()
    this.getPostList()
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
      this.userList.push(user);
    }
  }
  public getPostList = async () => {
    this.PService.getPost().subscribe((jsonData:Post[])=>this.m_posts=jsonData);
  }
  openDialog(id): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, {
      width: '400px',
      height: '150px',
    });
    dialogRef.componentInstance.idUser = id;
    dialogRef.afterClosed().subscribe(result => {
      this.router.routeReuseStrategy.shouldReuseRoute = () =>{
        return false;
      }
     this.refresh()
    });
  }
  openDialogPost(id): void {
    const dialogRef = this.dialog.open(DialogPostDetailComponent, {
      width: '400px',
      height: '400px',
    });
    dialogRef.componentInstance.m_post = this.m_posts.find(_=>_.id == id);
    dialogRef.afterClosed().subscribe(result => {
      this.router.routeReuseStrategy.shouldReuseRoute = () =>{
        return false;
      }
    });
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
