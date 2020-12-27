import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from './login.service'
import { ApiUrlConstants } from '../common/api-url.constants';
@Injectable({
    providedIn: 'root'
})
export class EditPasswordService {
    private urlAPI :string=ApiUrlConstants.API_URL;

    constructor(private http: HttpClient, private service : LoginService) {
        
    }
    public changePassword = async (iduser, formData) => {
        try {
            console.log(iduser);
             const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            return await this.http.put(this.urlAPI + ApiUrlConstants.API_UPDATE_PASSWORD_URL + iduser ,formData, config).toPromise();            
        }
        catch (e) {
            console.log(e);
        }
    }
}