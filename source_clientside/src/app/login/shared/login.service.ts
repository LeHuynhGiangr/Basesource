import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private urlAPI = 'https://localhost:44350/';
    private currentUser: BehaviorSubject<any>

    constructor(private http: HttpClient) {
        this.currentUser = new BehaviorSubject<any>(null);
    }

    getCurrrentUser(): any {
        return this.currentUser.value;
    }

    getUser = async () => {
        try {
       
            const config = {
                headers: {
                    Authorization: this.getConfigToken()
                }
            }
            const result = await this.http.get(this.urlAPI + 'user/load', config).toPromise();
            this.currentUser.next(result);
            return result;
        }
        catch (e) {
            console.log(e);
            // this.removeToken();
        }
    }

    sendOtp = async (email) => {
        try {

            console.log("tét email: ", email)

            const formData = new FormData();
            formData.append('email', email);

            return await this.http.post(this.urlAPI + "otp/send-email-otp", formData).toPromise();

        }
        catch (e) {
            alert("Send mail successfully");
        }
    }

    postUser = async (users) => {
        try {
            console.log(users);
            return await this.http.post(this.urlAPI + "identity/register", users).toPromise();

        }
        catch (e) {
            alert("Username are already registered or OTP wrong !");
        }
    }

    login = async (username, password) => {
        try {
            const data = {
                username,
                password
            };
            console.log("Login Successfully !");
            const res = await this.http.post(`${this.urlAPI}identity/authenticate`, data, { withCredentials: true }).toPromise() as any;

            if (res) {
                this.setToken(res.jwtToken);
                await this.getUser();
            }
            return res;
        }
        catch (e) {
            console.log(e);
        }
    };

    logout = () => {
        this.removeToken();
        this.currentUser.next(null);
    }

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