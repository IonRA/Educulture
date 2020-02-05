import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Enrollment } from '../_models/enrollment.interface';

@Injectable()

export class EnrollmentsService {

    baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    create(enrollment: Enrollment): Observable<Enrollment> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(enrollment)
        return this.http.post<Enrollment>(this.baseUrl + '/Enrollments/CreateEnrollment', JSON.stringify(enrollment), { headers: headers })
    }

    delete(id): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.delete<any>(this.baseUrl + '/Enrollments/DeleteEnrollment/' + id, { headers: headers })
    }
}