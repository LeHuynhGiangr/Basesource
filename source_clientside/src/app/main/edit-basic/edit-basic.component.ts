import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { EditBasicService } from './shared/edit-basic.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
@Component({
    selector: 'app-edit-basic',
    templateUrl: './edit-basic.component.html',
    styleUrls: ['./edit-basic.component.css']
})
export class EditBasicComponent implements OnInit {

  appUsers:Array<AppUsers>
  public Id: string = ''
  public m_returnUrl: string;
  public userId : string
  public FName: string = ''
  public LName: string = ''
  public Name: string = ''
  public Email: string = ''
  public Gender: string = ''
  public Location: Float32Array
  public PhoneNumber: string = ''
  public Image: string
  public Description: string = ''
  public Address: string = ''
  public Works : string =''
  public dataset: AppUsers[]
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService, 
  private EBService: EditBasicService, private m_route: ActivatedRoute, private m_router: Router,public dialog: MatDialog) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    var user = await this.service.getUser();
    this.userId = user["id"].toString();
    console.log(user["firstName"]+" "+user["lastName"]);
    this.Name=user["firstName"]+" "+user["lastName"];
    this.FName=user["firstName"];
    this.LName=user["lastName"];
    this.Image = user["avatar"];
    this.Email = user["email"];
    this.Gender = user["gender"];
    this.Works = user["works"]
    this.Location = user["location"];
    this.PhoneNumber = user["phoneNumber"];
    this.Address = user["address"];
    this.Description = user["description"];
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
  onSubmit() {
    console.log('title is:');
  }
  onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.userId);
      if (1) {
        formData.append('firstName', this.FName);
        formData.append('lastName', this.LName);
        formData.append('description', this.Description);
        formData.append('email', this.Email);
        formData.append('address', this.Address);
        formData.append('gender', this.Gender);
        formData.append('phoneNumber', this.PhoneNumber);
        formData.append('works', this.Works);
        this.EBService.uploadProfile(this.userId,formData);
        alert("Upload succesfully !")
        this.refresh();
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
}
