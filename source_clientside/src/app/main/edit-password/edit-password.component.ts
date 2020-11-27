import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { EditPasswordService } from './shared/edit-password.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
@Component({
    selector: 'app-edit-password',
    templateUrl: './edit-password.component.html',
    styleUrls: ['./edit-password.component.css']
})
export class EditPasswordComponent implements OnInit {

  appUsers:Array<AppUsers>
  public Id: string = ''
  public Name: string = ''
  public Image: string
  public Description: string = ''
  public Password :string = ''
  public ConfirmPassword :string = ''
  public m_returnUrl: string;
  public dataset: AppUsers[]
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService,public dialog: MatDialog,
  private EPservice:EditPasswordService,private m_route: ActivatedRoute, private m_router: Router) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    var user = await this.service.getUser();
    this.Id = user["id"].toString();
    console.log(user["firstName"]+" "+user["lastName"]);
    this.Name=user["firstName"]+" "+user["lastName"];
    this.Image = user["avatar"]
    this.Description = user["description"]
  }
  getPath(){
    return this.router.url;
  }
  getImageMime(base64: string): string
  {
    return 'jpg';
  }
  getImageSource(base64: string): string
  {
    return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
  }
  onFileChanged(event) {
    this.Image = event.target.files[0]
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogUploadAvatarComponent, {
      width: '500px',
      height: '400px',
      data: { Id: this.Id }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
      this.service.getUser().then(user => {
        if (user) {
          console.log(user["firstName"] + " " + user["lastName"]);
          this.Id = user["id"].toString();
          this.Name = user["firstName"] + " " + user["lastName"];
          this.Image = user["avatar"]
        }
      });
    });
  }
  onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.Id);
      if (1) {
        formData.append('password', this.Password);
        formData.append('confirmPassword', this.ConfirmPassword);
        if (this.Password !== this.ConfirmPassword) {
          return alert('Password not match a confirm password');
        }
        else
        {
          this.EPservice.changePassword(this.Id,formData);
          alert("Upload succesfully !")
          this.refresh();
        }
        
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
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/about';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    //window.location.reload();
  }
}
