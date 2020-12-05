import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
import { EditInterestService } from './shared/edit-hobby.service';
import { DialogUploadBackgroundComponent } from '../timeline/dialog-uploadbackground/dialog-uploadbackground.component';
import { UserProfile } from '../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
    selector: 'app-edit-hobby',
    templateUrl: './edit-hobby.component.html',
    styleUrls: ['./edit-hobby.component.css']
})
export class EditHobbyComponent implements OnInit {

  public appUsers: AppUsers;
  public m_returnUrl: string;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService,public dialog: MatDialog,
  private m_route: ActivatedRoute, private m_router: Router,private ETService:EditInterestService,public uriHandler:UriHandler) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    //var user = await this.service.getUser();
    this.appUsers.Id = UserProfile.Id
    //console.log(user["firstName"]+" "+user["lastName"]);
    this.appUsers.FirstName = UserProfile.FirstName
    this.appUsers.LastName = UserProfile.LastName
    this.appUsers.Avatar = UserProfile.Avatar
    this.appUsers.Language = UserProfile.Language
    this.appUsers.Hobby = UserProfile.Hobby
    this.appUsers.Background = UserProfile.Background
  }
  getPath(){
    return this.router.url;
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
  
  async onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.appUsers.Id);
      if (1) {
        formData.append('hobby', this.appUsers.Hobby);
        formData.append('language', this.appUsers.Language);
        this.ETService.uploadProfile(this.appUsers.Id,formData);
        alert("Upload succesfully !")
        
        //Refresh user after edit interest
        var user = await this.service.getUser();
        UserProfile.Hobby = user["hobby"]
        UserProfile.Language = user["language"]
        this.refresh();
      }
      else
      {
        alert("Upload failure !")
      }
    }
    catch(e)
    {
      alert("Upload failure !")
    }
  }
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/about';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    //window.location.reload();
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
