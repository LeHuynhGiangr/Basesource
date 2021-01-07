import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../../../_core/models/DialogData';
import { LoginService } from '../../../_core/services/login.service';
import { PagesService } from '../../../_core/services/page.service';
import { AppUsers } from '../../../login/shared/login.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { ImageService } from '../../../_core/services/images.service';
import { PageStatic } from 'src/app/_core/data-repository/page';
import {Pages} from '../../../_core/models/pages.model'
@Component({
  selector: 'app-dialog-uploadpagebackground',
  templateUrl: './dialog-uploadpagebackground.component.html',
  styleUrls: ['./dialog-uploadpagebackground.component.css']
})
export class DialogUploadPageBackgroundComponent implements OnInit {
  public background: File
  public m_returnUrl: string;
  url;
  public message: string;
  public pages: Pages;
  constructor(public dialogRef: MatDialogRef<DialogUploadPageBackgroundComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData, private service: LoginService,
    private PService: PagesService,private m_route: ActivatedRoute,private m_router: Router,public uriHandler:UriHandler,
    public Iservice:ImageService) {

  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  async ngOnInit() {
    this.m_router.routeReuseStrategy.shouldReuseRoute = () =>{
      return false;
    }
    console.log(PageStatic.Id)
    this.pages=new Pages()
    this.pages.Id = PageStatic.Id
    this.pages.Background = PageStatic.Background

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
  async saveImage()
  {
      const formData = new FormData();
      if (Image) {
        formData.append('MediaFile', this.background);
        this.Iservice.postImage(formData);
        //this.dialogRef.close();
      }
      else
      {
        alert("Upload failure !")
      }

  }
  async onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.pages.Id);
      if (Image) {
        formData.append('background', this.background);
        await this.PService.uploadBackground(formData);
        //this.saveImage()
        alert("Upload succesfully !")
        this.dialogRef.close();
        //this.refresh()
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
}