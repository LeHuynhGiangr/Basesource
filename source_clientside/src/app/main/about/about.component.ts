import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
import { DialogUploadBackgroundComponent } from '../timeline/dialog-uploadbackground/dialog-uploadbackground.component';
import { UserProfile } from '../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
    selector: 'app-about',
    templateUrl: './about.component.html',
    styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  public appUsers: AppUsers;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService,
  private m_route: ActivatedRoute, private m_router: Router,public dialog: MatDialog, public uriHandler:UriHandler) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    //var user = await this.service.getUser();
    //console.log(user["firstName"]+" "+user["lastName"]);
    this.appUsers.FirstName=UserProfile.FirstName
    this.appUsers.LastName=UserProfile.LastName
    this.appUsers.Avatar = UserProfile.Avatar
    this.appUsers.Descriptions = UserProfile.Description
    this.appUsers.Address = UserProfile.Address
    this.appUsers.PhoneNumber = UserProfile.PhoneNumber
    this.appUsers.Email = UserProfile.Email
    this.appUsers.BirthDay= UserProfile.BirthDay
    this.appUsers.AcademicLevel = UserProfile.AcademicLevel
    this.appUsers.AddressAcademic = UserProfile.AddressAcademic
    this.appUsers.DescriptionAcademic = UserProfile.DescriptionAcademic
    this.appUsers.StudyingAt = UserProfile.StudyingAt
    this.appUsers.FromDate = UserProfile.FromDate
    this.appUsers.ToDate = UserProfile.ToDate
    this.appUsers.Hobby = UserProfile.Hobby
    this.appUsers.Language = UserProfile.Language
    this.appUsers.Background = UserProfile.Background
    this.appUsers.Gender = UserProfile.Gender
    //console.log(UriHandler.getImageSource(this.appUsers.Avatar))
  }
  getPath(){
    return this.router.url;
  }
  
  // getImageMime(base64: string): string
  // {
  //   if (base64.charAt(0)=='/') return 'jpg';
  //   else if (base64.charAt(0)=='R') return "gif";
  //   else if(base64.charAt(0)=='i') return 'png';
  //   else return 'jpeg';
  // }
  // getImageSource(base64: string): string
  // {
  //   return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
  // }
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
