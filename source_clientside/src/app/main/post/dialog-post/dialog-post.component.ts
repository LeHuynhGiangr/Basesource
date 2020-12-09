import { Component, OnInit, Inject, NgModule } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoginService } from '../../../login/shared/login.service';
import { AppUsers } from '../../../login/shared/login.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
@Component({
  selector: 'app-dialog-post',
  templateUrl: './dialog-post.component.html',
  styleUrls: ['./dialog-post.component.css']
})
export class DialogPostComponent implements OnInit {
  public appUsers: AppUsers;
  public background: File
  public m_returnUrl: string;
  url;
  public m_status: string="";
  constructor(public dialogRef: MatDialogRef<DialogPostComponent>, @Inject(MAT_DIALOG_DATA) private service: LoginService,
    private m_route: ActivatedRoute,private m_router: Router,public uriHandler:UriHandler) {

  }
  onNoClick(): void {
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
      }

      // Saved Image into varible
      this.background = event.target.files[0];
    }
  }

  async onSave() {
  }
  
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    //window.location.reload();
  }

  onPost(status){
    this.m_status=status;
    alert(this.m_status);
  }

  onCancel(){
    this.m_status="";
    this.background=null;
    this.dialogRef.close();
  }
}