import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DialogData } from '../shared/DialogData';
import { LoginService } from '../../../login/shared/login.service';
@Component({
    selector: 'app-dialog-uploadavatar',
    templateUrl: './dialog-uploadavatar.component.html',
    styleUrls: ['./dialog-uploadavatar.component.css']
  })
  export class DialogUploadAvatarComponent implements OnInit {
    public Image: string
    public imagePath;
    imgURL: any;
    url;
    msg = "";
    public message: string;
    constructor(public dialogRef: MatDialogRef<DialogUploadAvatarComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData, private service :LoginService) 
    {

    }
    onNoClick(): void {
        this.dialogRef.close();
    }

    handleFileInput(files: FileList) {
    console.log(files.item(0));
    if (files.item(0))
      this.data.Image = files.item(0);  //Lấy file uplload hình gán vào biến
    }
    
    async ngOnInit()
    {
      var user = await this.service.getUser();
      this.Image = user["avatar"]
    }

    getImageMime(base64: string): string
    {
      return 'jpg';
    }
    getImageSource(base64: string): string
    {
      return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
    }
    onSelectFile(event) {
      if (event.target.files && event.target.files[0]) {
        var reader = new FileReader();
  
        reader.readAsDataURL(event.target.files[0]); // read file as data url
  
        reader.onload = (event) => { // called once readAsDataURL is completed
          this.url = event.target.result;
        }
      }
    }
  }