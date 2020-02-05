import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '../../../node_modules/@angular/core';
import { Inject } from '@angular/core';
import { Observable } from '../../../node_modules/rxjs';
import { User } from '../_models/user.interface';

@Injectable()

export class UsersService {

    baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    login(username, password): Observable<User> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.post<User>(this.baseUrl + '/Users/Login?username=' + username + '&password=' + password, { headers: headers })
    }

    create(user: User): Observable<User> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(user)
        return this.http.post<User>(this.baseUrl + '/Users/CreateUser', JSON.stringify(user), { headers: headers })
    }

    getAll(): Observable<User[]> {
        console.log("getall service from: " + this.baseUrl + '/Users/GetAllUsers')
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<User[]>(this.baseUrl + '/Users/GetAllUsers', { headers: headers })
    }

    getById(id: number): Observable<User> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<User>(this.baseUrl + '/Users/GetUserById/' + id, { headers: headers })
    }

    update(user: User): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(user)
        return this.http.put<any>(this.baseUrl + '/Users/UpdateUser', JSON.stringify(user), { headers: headers })
    }

    delete(id): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.delete<any>(this.baseUrl + '/Users/DeleteUser/' + id, { headers: headers })
    }
}