import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../shared/DialogData';
import { LoginService } from '../../../login/shared/login.service';
import { TimeLineService } from '../shared/timeline.service';
import { AppUsers } from '../../../login/shared/login.model';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-dialog-uploadbackground',
  templateUrl: './dialog-uploadbackground.component.html',
  styleUrls: ['./dialog-uploadbackground.component.css']
})
export class DialogUploadBackgroundComponent implements OnInit {
  public appUsers: AppUsers;
  public background: File
  public m_returnUrl: string;
  url;
  public message: string;
  constructor(public dialogRef: MatDialogRef<DialogUploadBackgroundComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData, private service: LoginService,
    private timeLineService: TimeLineService,private m_route: ActivatedRoute,private m_router: Router) {

  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  async ngOnInit() {
    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.Background = user["background"]
    this.appUsers.Id=user["id"]
  }

  getImageMime(base64: string): string {
    return 'jpg';
  }
  getImageSource(base64: string): string {
    return `data:image/${this.getImageMime(base64)};base64,${base64}`;
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
      this.background = event.target.files[0];
    }
  }

  onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.appUsers.Id);
      if (Image) {
        formData.append('background', this.background);
        this.timeLineService.uploadBackground(this.appUsers.Id, formData);
        alert("Upload succesfully !")
        this.dialogRef.close();
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