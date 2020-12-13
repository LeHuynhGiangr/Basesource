import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from '../../../login/shared/login.model';
import { LoginService } from '../../../login/shared/login.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
    selector: 'app-trip-dialog',
    templateUrl: './trip-dialog.component.html',
    styleUrls: ['./trip-dialog.component.css']
  })
  export class TripDialogComponent implements OnInit {
    public appUsers: AppUsers;
    constructor(public dialogRef: MatDialogRef<TripDialogComponent>,private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
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