import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from './login.service'
import { ApiUrlConstants } from '../common/api-url.constants';
@Injectable({
    providedIn: 'root'
})
export class EditBasicService {
    private urlAPI :string=ApiUrlConstants.API_URL;

    constructor(private http: HttpClient, private service : LoginService) {
        
    }
    public uploadProfile = async (iduser, formData) => {
        try {
            console.log(iduser);
             const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            return await this.http.put(this.urlAPI + ApiUrlConstants.API_UPDATE_PROFILE_URL + iduser ,formData, config).toPromise();            
        }
        catch (e) {
            console.log(e);
        }
    }
}