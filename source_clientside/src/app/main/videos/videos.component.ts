import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
import { DialogUploadBackgroundComponent } from '../timeline/dialog-uploadbackground/dialog-uploadbackground.component';
import { UserProfile } from 'src/app/_core/data-repository/profile';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { TimelineUrl } from 'src/app/_helpers/get-timeline-url';
@Component({
    selector: 'app-videos',
    templateUrl: './videos.component.html',
    styleUrls: ['./videos.component.css']
})
export class VideosComponent implements OnInit {

  public appUsers: AppUsers;
  public m_returnUrl: string;
  compareId: boolean;
  constructor(private m_route: ActivatedRoute, private m_router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService, public dialog: MatDialog,
  public uriHandler:UriHandler,public timelineurl:TimelineUrl) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    console.log(UserProfile.IdTemp)
    console.log(UserProfile.Id)
    if(UserProfile.Id==UserProfile.IdTemp)
    {
      this.compareId =true
      this.appUsers.FirstName=UserProfile.FirstName;
      this.appUsers.LastName=UserProfile.LastName;
      this.appUsers.Avatar = UserProfile.Avatar;
      this.appUsers.Background = UserProfile.Background;
    }

    if(UserProfile.Id!=UserProfile.IdTemp)
    {
      this.compareId = false
      const user =await this.service.getUserById(UserProfile.IdTemp)
      this.appUsers.FirstName = user["firstName"]
      this.appUsers.LastName = user["lastName"]
      this.appUsers.Avatar = user["avatar"]
      this.appUsers.Background = user["background"]
    }
  }

  onLogout() {
    this.service.logout();
    this.m_router.navigateByUrl('/login');
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
  public getNavigation( id) {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/timeline/'+id;
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
  }
}
