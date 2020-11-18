import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private urlAPI = 'https://localhost:44350/';

    constructor(private http: HttpClient) {

    }

    getUser = async () => {
        try {

            console.log(this.getToken());

            const config = {
                headers: {
                    Authorization: this.getConfigToken()
                }
            }

            return await this.http.get(this.urlAPI + 'user/load', config).toPromise();
        }
        catch (e) {
            console.log(e);
            this.removeToken();
        }
    }

    postUser = async (users) => {
        try {
            console.log(users);
            return await this.http.post(this.urlAPI + "identity/register", users).toPromise();
            
        }
        catch (e) {
            console.log(e);
        }
    }

    login = async (username, password) => {
        try {

            const data = {
                username,
                password
            };

            
            console.log("kjdshflkdsjf");

            const res = await this.http.post(`${this.urlAPI}identity/authenticate`, data).toPromise() as any;
            //phải chạy hàm này trước rồi token nó mới có hiệu lực để sài qua kia, căng

            console.log(res)

            if (res) {
                console.log(res.jwtToken);
                this.setToken(res.jwtToken);
            }

            return res;
        }
        catch (e) {
            console.log(e);
        }
    };


    setToken = (token) => {
        localStorage.setItem('token', token);
    };

    removeToken = () => {
        localStorage.removeItem('token');
    }

    getToken = () => {
        return localStorage.getItem('token');
    };

    getConfigToken = () => {
        const token = this.getToken();

        return token ? 'Bearer ' + token : undefined;
    }

}