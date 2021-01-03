import { Component, Input, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from '../../admin/admin.service';
@Component({
    selector: 'app-dialog-delete',
    templateUrl: './dialog-delete.component.html',
    styleUrls: ['./dialog-delete.component.css']
  })
  export class DialogDeleteComponent implements OnInit {
    public idUser
    constructor(public dialogRef: MatDialogRef<DialogDeleteComponent>, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,private m_route: ActivatedRoute,private m_router: Router,
    private Aservice: AdminService) {
    }
    async ngOnInit() {
        
    }
    deleteUser(id){
      alert("Delete successfully !")
      this.Aservice.deleteUser(id)
      this.dialogRef.close();
    }
    onNoClick(): void {
        this.dialogRef.close();
    }
}