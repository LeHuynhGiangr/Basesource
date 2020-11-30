import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor() { }
  
  public convertBase64StringToJPG(base64String:string){
    return 'data:image/jpg;base64,'+base64String;
  }
}
