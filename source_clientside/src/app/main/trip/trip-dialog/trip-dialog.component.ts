import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from '../../../login/shared/login.model';
import { TripService } from './../shared/trip.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
    selector: 'app-trip-dialog',
    templateUrl: './trip-dialog.component.html',
    styleUrls: ['./trip-dialog.component.css']
  })
  export class TripDialogComponent implements OnInit {
    public appUsers: AppUsers;
    public Image: File
    public Name : string
    public Description : string
    public Location :Float32Array
    public m_returnUrl: string;
    url;
    constructor(public dialogRef: MatDialogRef<TripDialogComponent>, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
      private service: TripService,private m_route: ActivatedRoute,private m_router: Router) {
    }
    async ngOnInit() {
        
    }
    onNoClick(): void {
        this.dialogRef.close();
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
      this.Image = event.target.files[0];
    }
  }
  async onSave() {
    try{
      const formData = new FormData();
      if (Image) {
        formData.append('image', this.Image);
        formData.append('description',this.Description)
        formData.append('name',this.Name)
        formData.append('location',"1")
        this.service.createTrip(formData);
        alert("Create succesfully !")
        this.dialogRef.close();
        this.refresh()
      }
      else
      {
        alert("Create failure !")
      }
    }
    catch(e)
    {
      alert("Upload failure !")
    }
  }
  
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/trip';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    
    //window.location.reload();
  }
}