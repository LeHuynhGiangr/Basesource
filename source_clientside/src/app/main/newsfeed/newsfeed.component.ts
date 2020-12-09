import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { PostService } from 'src/app/_core/services/post.service';
import { UserProfile } from '../../_core/data-repository/profile'
import { MatDialog } from '@angular/material/dialog';
import { DialogPostComponent } from '../post/dialog-post/dialog-post.component';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { CreatePostRequest } from 'src/app/_core/models/models.request/CreatePostRequest';
import { Post } from 'src/app/_core/models/Post';
@Component({
    selector: 'app-newsfeed',
    templateUrl: './newsfeed.component.html',
    styleUrls: ['./newsfeed.component.css']
})
export class NewsfeedComponent implements OnInit {
  public m_posts:Post[];

  public appUsers: AppUsers;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService, 
  private m_postService:PostService,public dialog: MatDialog,public uriHandler:UriHandler) { 
    this.loadPostData();
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    console.log(user["firstName"]+" "+user["lastName"]);
    this.appUsers.Avatar = user["avatar"];
    this.getProfile(user);
    
  }

  loadPostData(){
      this.m_postService.getPost().subscribe((jsonData:Post[])=>this.m_posts=jsonData);
  }

  createPost(newPost:CreatePostRequest){
    if(!newPost)return;
    //const createPostRequest:CreatePostRequest
  }

  getProfile(user)
  {   
    UserProfile.FirstName = user["firstName"]
    UserProfile.LastName = user["lastName"]
    UserProfile.Avatar = user["avatar"]
    UserProfile.Background = user["background"]
    UserProfile.Language = user["language"]
    UserProfile.Location = user["location"]
    UserProfile.Password = user["password"]
    UserProfile.PhoneNumber = user["phoneNumber"]
    UserProfile.RequestFriend = user["requestFriend"]
    UserProfile.StudyingAt = user["studyingAt"]
    UserProfile.ToDate = user["toDate"]
    UserProfile.ViewListFriend = user["viewListFriend"]
    UserProfile.ViewTimeLine = user["viewTimeLine"]
    UserProfile.Works = user["works"]
    UserProfile.AcademicLevel = user["academicLevel"]
    UserProfile.AddressAcademic = user["addressAcademic"]
    UserProfile.ConfirmPassword = user["confirmPassword"]
    UserProfile.DescriptionAcademic = user["descriptionAcademic"]
    UserProfile.FollowMe = user["followMe"]
    UserProfile.Gender = user["gender"]
    UserProfile.Hobby = user["hobby"]
    UserProfile.Email = user["email"]
    UserProfile.FromDate = user["fromDate"]
    UserProfile.Description = user["description"]
    UserProfile.BirthDay = user["birthDay"]
    UserProfile.Address = user["address"]
    UserProfile.UserName = user["userName"]
  }
  getPath(){
    return this.router.url;
  }
  onLogout() {
    this.service.logout();

    this.router.navigateByUrl('/login');
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(DialogPostComponent, {
      width: '800px',
      height: '300px',
      data: { Id: this.appUsers.Id }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
      this.service.getUser().then(user => {
        if (user) {
          console.log(user["firstName"] + " " + user["lastName"]);
          this.appUsers.Id = user["id"].toString();
        }
      });
    });
  }
}