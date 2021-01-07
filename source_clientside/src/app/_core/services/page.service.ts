import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from './login.service'
import { ApiUrlConstants } from '../common/api-url.constants';
@Injectable({
    providedIn: 'root'
})
export class PagesService {
    private urlAPI :string=ApiUrlConstants.API_URL;

    constructor(private http: HttpClient,private service : LoginService) {

    }
    postPage = async (page) => {
        try {
            const result = await this.http.post(this.urlAPI + ApiUrlConstants.API_PAGEID_URL,page).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
        }
    }
    getAllPages = async () => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + ApiUrlConstants.API_PAGE_URL, config).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    getPageById = async (id) => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + ApiUrlConstants.API_PAGEID_URL+id, config).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    uploadAvatar = async (formData) => {
        try {
            // const config = {
            //     headers: {
            //         Authorization: this.service.getConfigToken()
            //     }
            // }
            return await this.http.put(this.urlAPI + ApiUrlConstants.API_UPDATE_PAGEAVATAR_URL,formData ).toPromise();            
        }
        catch (e) {
            console.log("ok");
        }
    }
    uploadBackground = async (formData) => {
        try {
             const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            return await this.http.put(this.urlAPI + ApiUrlConstants.API_UPDATE_PAGEBACKGROUND_URL ,formData, config).toPromise();            
        }
        catch (e) {
            console.log("ok");
        }
    }
}