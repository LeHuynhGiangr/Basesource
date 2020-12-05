import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { MatDialog } from '@angular/material/dialog';
import { EditSettingService } from './shared/edit-setting.service';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
import { DialogUploadBackgroundComponent } from '../timeline/dialog-uploadbackground/dialog-uploadbackground.component';
import { UserProfile } from '../../_core/data-repository/profile'
@Component({
    selector: 'app-edit-setting',
    templateUrl: './edit-setting.component.html',
    styleUrls: ['./edit-setting.component.css']
})
export class EditSettingComponent implements OnInit {

  public appUsers: AppUsers;
  public m_returnUrl: string;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService,public dialog: MatDialog,
   private m_route: ActivatedRoute, private m_router: Router, private ESService: EditSettingService) {
    
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
    this.appUsers.Email = UserProfile.Email
    this.appUsers.Gender = UserProfile.Gender
    this.appUsers.Works = UserProfile.Works
    this.appUsers.Location = UserProfile.Location
    this.appUsers.PhoneNumber = UserProfile.PhoneNumber
    this.appUsers.Address = UserProfile.Address
    this.appUsers.Descriptions = UserProfile.Description
    this.appUsers.BirthDay = UserProfile.BirthDay
    this.appUsers.Background = UserProfile.Background
    this.appUsers.FollowMe = UserProfile.FollowMe
    this.appUsers.RequestFriend = UserProfile.RequestFriend
    this.appUsers.ViewListFriend = UserProfile.ViewListFriend
    this.appUsers.ViewTimeLine = UserProfile.ViewTimeLine
  }
  async onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.appUsers.Id);
      if (1) {
        formData.append('firstName', this.appUsers.FirstName);
        formData.append('lastName', this.appUsers.LastName);
        formData.append('description', this.appUsers.Descriptions);
        formData.append('email', this.appUsers.Email);
        formData.append('address', this.appUsers.Address);
        formData.append('gender', this.appUsers.Gender);
        formData.append('phoneNumber', this.appUsers.PhoneNumber);
        formData.append('works', this.appUsers.Works);
        formData.append('birthDay', this.appUsers.BirthDay.toString());
        formData.append('followMe', this.appUsers.FollowMe.toString());
        formData.append('requestFriend', this.appUsers.RequestFriend.toString());
        formData.append('viewTimeLine', this.appUsers.ViewTimeLine.toString());
        formData.append('viewListFriend', this.appUsers.ViewListFriend.toString());
        formData.append('gender', this.appUsers.Gender);
        formData.append('phoneNumber', this.appUsers.PhoneNumber);
        formData.append('works', this.appUsers.Works);
        this.ESService.uploadProfile(this.appUsers.Id,formData);
        alert("Upload succesfully !")

        //Refresh user after edit interest
        var user = await this.service.getUser();
        UserProfile.ViewListFriend = user["viewListFriend"]
        UserProfile.ViewTimeLine = user["viewTimeLine"]
        UserProfile.FollowMe = user["followMe"]
        UserProfile.RequestFriend = user["requestFriend"]
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
  getPath(){
    return this.router.url;
  }
  getImageMime(base64: string): string
  {
    if (base64.charAt(0)=='/') return 'jpg';
    else if (base64.charAt(0)=='R') return "gif";
    else if(base64.charAt(0)=='i') return 'png';
    else return 'jpeg';
  }
  getImageSource(base64: string): string
  {
    return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
  }
  onFileChanged(event) {
    this.appUsers.Avatar = event.target.files[0]
  }
  onChange1 = (event: any) => {
    this.appUsers.ViewTimeLine = event.target.value;
  }
  onChange2 = (event: any) => {
    this.appUsers.FollowMe = event.target.value;
  }
  onChange3 = (event: any) => {
    this.appUsers.ViewListFriend = event.target.value;
  }
  onChange4 = (event: any) => {
    this.appUsers.RequestFriend = event.target.value;
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
