import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from '../../../login/shared/login.service'
@Injectable({
    providedIn: 'root'
})
export class ImageService {
    private urlAPI = 'https://localhost:44350/';

    constructor(private http: HttpClient,private service : LoginService) {

    }
    getImageUser = async (id) => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + 'media/load/'+id, config).toPromise();
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
            return await this.http.post(this.urlAPI + "media/" ,formData, config).toPromise();            
        }
        catch (e) {
            console.log("ok");
        }
    }
}