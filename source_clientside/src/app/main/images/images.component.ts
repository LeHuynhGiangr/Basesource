import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
import { DialogUploadBackgroundComponent } from '../timeline/dialog-uploadbackground/dialog-uploadbackground.component';
import { UserProfile } from '../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
    selector: 'app-images',
    templateUrl: './images.component.html',
    styleUrls: ['./images.component.css']
})
export class ImagesComponent implements OnInit {

  public appUsers: AppUsers;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService,public dialog: MatDialog,
  public uriHandler:UriHandler) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    //var user = await this.service.getUser();
    //console.log(user["firstName"]+" "+user["lastName"]);
    this.appUsers.Id=UserProfile.Id
    this.appUsers.FirstName=UserProfile.FirstName
    this.appUsers.LastName=UserProfile.LastName
    this.appUsers.Avatar = UserProfile.Avatar
    this.appUsers.Background = UserProfile.Background
    }
    getPath(){
      return this.router.url;
    }
    onLogout() {
      this.service.logout();
      this.router.navigateByUrl('/login');
    }
    onFileChanged(event) {
      this.appUsers.Avatar = event.target.files[0]
    }

    openDialog(): void {
      const dialogRef = this.dialog.open(DialogUploadAvatarComponent, {
        width: '500px',
        height: '400px',
        data: { Id: this.appUsers.Id }
      });

      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        console.log(result);
        this.service.getUser().then(user => {
          if (user) {
            console.log(user["firstName"] + " " + user["lastName"]);
            this.appUsers.Id = user["id"].toString();
            this.appUsers.Avatar = user["avatar"]
          }
        });
      });
    }
    openDialogBackground(): void {
      const dialogRef = this.dialog.open(DialogUploadBackgroundComponent, {
        width: '500px',
        height: '400px',
        data: { Id: this.appUsers.Id }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        console.log(result);
        this.service.getUser().then(user => {
          if (user) {
            console.log(user["firstName"] + " " + user["lastName"]);
            this.appUsers.Id = user["id"].toString();
            this.appUsers.Background = user["background"]
          }
        });
  
      });
    }
}
