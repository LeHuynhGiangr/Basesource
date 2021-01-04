import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { LoginService } from '../../_core/services/login.service';
import {PageStatic} from 'src/app/_core/data-repository/page'
import { PagesService } from '../../_core/services/page.service';
import {Pages} from '../../_core/models/pages.model'
import { TripDialogComponent } from 'src/app/main/trip/trip-dialog/trip-dialog.component';
import { ApiUrlConstants } from '../../../../src/app/_core/common/api-url.constants';
import { MatDialog } from '@angular/material/dialog';
@Component({
    selector: 'app-fanpage',
    templateUrl: './fanpage.component.html',
    styleUrls: ['./fanpage.component.css']
})
export class FanpageComponent implements OnInit {
    public pages: Pages;
    constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService,
    private PService:PagesService,public dialog: MatDialog) {}

    ngOnInit() {
      var script = document.createElement("script");
      script.type = "text/javascript";
      script.src = "../assets/js/script.js";
      this.elementRef.nativeElement.appendChild(script);
      this.getPage()
    }
    async getPage(){
      this.pages = new Pages()
      this.pages.Name =  PageStatic.Name
      this.pages.Avatar = ApiUrlConstants.API_URL+"/"+PageStatic.Avatar
      this.pages.Background = ApiUrlConstants.API_URL+"/"+PageStatic.Background
    }
    CreateTripDialog(): void {
      const dialogRef = this.dialog.open(TripDialogComponent, {
        width: '600px',
        height: '600px',
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        console.log(result);
      });
    }
    onLogout() {
      this.service.logout();
      this.router.navigateByUrl('/login');
    }
}
