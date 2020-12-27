import { Component, OnInit, Inject, NgModule } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoginService } from '../../../_core/services/login.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-dialog-post',
  templateUrl: './dialog-post.component.html',
  styleUrls: ['./dialog-post.component.css']
})
export class DialogPostComponent implements OnInit {
  //public appUsers: AppUsers;
  //public m_authoId:string;
  public m_image: string;
  public m_returnUrl: string;
  public url:any;
  public m_status: string="";
  public isCloseByCancelBtn=1;
  constructor(public dialogRef: MatDialogRef<DialogPostComponent>, @Inject(MAT_DIALOG_DATA) private service: LoginService,
    private m_route: ActivatedRoute,private m_router: Router) {

  }
  onNoClick(): void {
    this.isCloseByCancelBtn=1;
    this.dialogRef.close();
  }

  async ngOnInit() {
  }

  //display image before upload
  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed
        this.url = event.target.result;
        const indexOfComma:number=(this.url+'').indexOf(',');
        this.m_image=(this.url+'').slice(indexOfComma+1);
      }
    }
  }

  async onSave() {
  }
  
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    this.isCloseByCancelBtn=1;
    //window.location.reload();
  }

  onPost(status){
    this.m_status=status;
    alert(this.m_status);
    this.isCloseByCancelBtn=0;
    this.dialogRef.close();
  }

  onCancel(){
    this.m_status="";
    this.m_image=null;
    this.isCloseByCancelBtn=1;
    this.dialogRef.close()
  }
}