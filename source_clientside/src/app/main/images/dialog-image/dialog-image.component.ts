import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoginService } from '../../../_core/services/login.service';
import { ImageService } from '../../../_core/services/images.service';
import {Images} from '../../../_core/models/images.model'
import { AppUsers } from '../../../login/shared/login.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UserProfile } from '../../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { ImageInfo } from 'src/app/_core/data-repository/image';
@Component({
  selector: 'app-dialog-image',
  templateUrl: './dialog-image.component.html',
  styleUrls: ['./dialog-image.component.css']
})
export class DialogShowImageComponent implements OnInit {
    public images: Images;
    public image: File
    public m_returnUrl: string;
    url;
    public message: string;
    constructor(public dialogRef: MatDialogRef<DialogShowImageComponent>, @Inject(MAT_DIALOG_DATA) private service: LoginService, 
    private m_route: ActivatedRoute,private m_router: Router,public uriHandler:UriHandler,
      public Iservice:ImageService) {
  
    }
    onNoClick(): void {
      this.dialogRef.close();
    }
  
    async ngOnInit() {
      this.images = new Images();
      this.images.Id = ImageInfo.Id
      this.images.Image = ImageInfo.Imgage
      this.m_router.routeReuseStrategy.shouldReuseRoute = () =>{
        return false;
      }
    }
}