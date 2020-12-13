import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from '../../../login/shared/login.model';
import { LoginService } from '../../../login/shared/login.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
    selector: 'app-addfriend-dialog',
    templateUrl: './addfriend-dialog.component.html',
    styleUrls: ['./addfriend-dialog.component.css']
  })
  export class AddFriendDialogComponent implements OnInit {
    typesOfShoes: string[] = ['Giang', 'Kiet', 'Hung', 'Dat', 'Duy'];
    durationInSeconds = 5;
    public appUsers: AppUsers;
    constructor(public dialogRef: MatDialogRef<AddFriendDialogComponent>,private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
      private service: LoginService) {
  
    }
    async ngOnInit() {
    }
    onSave(){

    }
    onNoClick(): void {
        this.dialogRef.close();
      }
}