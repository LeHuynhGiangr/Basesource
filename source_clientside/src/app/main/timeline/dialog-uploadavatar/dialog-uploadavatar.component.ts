import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../shared/DialogData';
import { LoginService } from '../../../login/shared/login.service';
import { TimeLineService } from '../shared/timeline.service';
import { UnsubscriptionError } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-dialog-uploadavatar',
  templateUrl: './dialog-uploadavatar.component.html',
  styleUrls: ['./dialog-uploadavatar.component.css']
})
export class DialogUploadAvatarComponent implements OnInit {
  public Image: string
  public avatar: File
  public imagePath;
  public m_returnUrl: string;
  url;
  public userId : string
  public message: string;
  constructor(public dialogRef: MatDialogRef<DialogUploadAvatarComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData, private service: LoginService,
    private timeLineService: TimeLineService,private m_route: ActivatedRoute,private m_router: Router) {

  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  handleFileInput(files: FileList) {
    console.log(files.item(0));
    if (files.item(0))
      this.data.Image = files.item(0);  //Lấy file uplload hình gán vào biến
  }

  async ngOnInit() {
    var user = await this.service.getUser();
    this.Image = user["avatar"]
    this.userId=user["id"]
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
      this.avatar = event.target.files[0];
    }
  }

  onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.userId);
      if (Image) {
        formData.append('avatar', this.avatar);
        this.timeLineService.uploadAvatar(this.userId, formData);
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