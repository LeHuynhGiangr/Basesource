import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from './../login/shared/login.service'
@Injectable({
    providedIn: 'root'
})
export class AdminService {
    private urlAPI = 'https://localhost:44350/';

    constructor(private http: HttpClient,private service : LoginService) {

    }
    getAllUsers = async () => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + 'admin', config).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    deleteUser = async (id) => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.delete(this.urlAPI + 'admin/'+id, config).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
    blockUser = async (id) => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.put(this.urlAPI + 'admin/block/'+id, config).toPromise();
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
}