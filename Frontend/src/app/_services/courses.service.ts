import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../_models/course.interface';

@Injectable()

export class CoursesService {

    baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    create(course: Course): Observable<Course> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(course)
        return this.http.post<Course>(this.baseUrl + '/Courses/CreateCourse', JSON.stringify(course), { headers: headers })
    }

    getAll(): Observable<Course[]> {
        console.log("getall service from: " + this.baseUrl + '/Courses/GetAllCourses')
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<Course[]>(this.baseUrl + '/Courses/GetAllCourses', { headers: headers })
    }

    getById(id: number): Observable<Course> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<Course>(this.baseUrl + '/Courses/GetCourseById/' + id, { headers: headers })
    }

    update(course: Course): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(course)
        return this.http.put<any>(this.baseUrl + '/Courses/UpdateCourse', JSON.stringify(course), { headers: headers })
    }

    delete(id): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.delete<any>(this.baseUrl + '/Courses/DeleteCourse/' + id, { headers: headers })
    }
}