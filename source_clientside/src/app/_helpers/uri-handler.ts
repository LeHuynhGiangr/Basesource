import { Injectable } from '@angular/core';

@Injectable({
    providedIn:'root'
})
export class UriHandler{
  private getImageMime(base64: string): string
  {
    var tempString=String(base64);
    if (tempString.charAt(0)=='/') return 'jpg';
    else if (tempString.charAt(0)=='R') return "gif";
    else if(tempString.charAt(0)=='i') return 'png';
    else return 'jpeg';
  }
  public getImageSource(base64: string): string
  {
    return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
  }
}