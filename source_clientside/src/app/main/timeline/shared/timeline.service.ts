import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from '../../../login/shared/login.service'
@Injectable({
    providedIn: 'root'
})
export class TimeLineService {
    private urlAPI = 'https://localhost:44350/';

    constructor(private http: HttpClient,private service : LoginService) {

    }
    uploadAvatar = async (iduser, formData) => {
        try {
            console.log(iduser);
             const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            return await this.http.put(this.urlAPI + "user/avatar/" + iduser ,formData, config).toPromise();            
        }
        catch (e) {
            console.log(e);
        }
    }
    uploadBackground = async (iduser, formData) => {
        try {
            console.log(iduser);
             const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            return await this.http.put(this.urlAPI + "user/background/" + iduser ,formData, config).toPromise();            
        }
        catch (e) {
            console.log(e);
        }
    }
}