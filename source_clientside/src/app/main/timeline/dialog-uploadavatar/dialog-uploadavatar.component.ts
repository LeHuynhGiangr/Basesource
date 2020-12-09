import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../shared/DialogData';
import { LoginService } from '../../../login/shared/login.service';
import { TimeLineService } from '../shared/timeline.service';
import { AppUsers } from '../../../login/shared/login.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UserProfile } from '../../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
  selector: 'app-dialog-uploadavatar',
  templateUrl: './dialog-uploadavatar.component.html',
  styleUrls: ['./dialog-uploadavatar.component.css']
})
export class DialogUploadAvatarComponent implements OnInit {
  public appUsers: AppUsers;
  public avatar: File
  public m_returnUrl: string;
  url;
  public message: string;
  constructor(public dialogRef: MatDialogRef<DialogUploadAvatarComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData, private service: LoginService,
    private timeLineService: TimeLineService,private m_route: ActivatedRoute,private m_router: Router,public uriHandler:UriHandler) {

  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  async ngOnInit() {
    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.Avatar = user["avatar"];
    this.appUsers.Id=UserProfile.Id
  }


  //display image before upload
  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed
        this.url = event.target.result;
      }

      // Saved Image into varible
      this.avatar = event.target.files[0];
    }
  }

  async onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.appUsers.Id);
      if (Image) {
        formData.append('avatar', this.avatar);
        this.timeLineService.uploadAvatar(this.appUsers.Id, formData);
        alert("Upload succesfully !")
        this.dialogRef.close();
        var user = await this.service.getUser();
        UserProfile.Avatar = user["avatar"]
        this.refresh()
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
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/timeline';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    //window.location.reload();
  }
}