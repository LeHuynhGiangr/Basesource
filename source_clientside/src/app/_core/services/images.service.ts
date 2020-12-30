import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from './login.service'
import { ApiUrlConstants } from '../common/api-url.constants';
@Injectable({
    providedIn: 'root'
})
export class ImageService {
    private urlAPI :string=ApiUrlConstants.API_URL;
    constructor(private http: HttpClient,private service : LoginService) {

    }
    getImageUser = async (id) => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + ApiUrlConstants.API_MEDIA_URL+'/load/'+id, config).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    postImage = async (formData) => {
        try {
             const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            return await this.http.post(this.urlAPI + ApiUrlConstants.API_MEDIA_URL ,formData, config).toPromise();            
        }
        catch (e) {
            console.log("ok");
        }
    }

}