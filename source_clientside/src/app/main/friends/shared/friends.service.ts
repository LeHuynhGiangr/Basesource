import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginService} from '../../../login/shared/login.service'
@Injectable({
    providedIn: 'root'
})
export class FriendService {
    private urlAPI = 'https://localhost:44350/';

    constructor(private http: HttpClient,private service : LoginService) {

    }
    getAllFriends = async () => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.service.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + 'user/search?name=', config).toPromise();
            console.log(result)
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }
}