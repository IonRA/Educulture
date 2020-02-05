import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseStage } from '../_models/course-stage.interface';

@Injectable()

export class CourseStagesService {

    baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    create(courseStage: CourseStage): Observable<CourseStage> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(courseStage)
        return this.http.post<CourseStage>(this.baseUrl + '/CourseStages/CreateCourseStage', JSON.stringify(courseStage), { headers: headers })
    }

    getAll(): Observable<CourseStage[]> {
        console.log("getall service from: " + this.baseUrl + '/CourseStages/GetAllCourseStages')
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<CourseStage[]>(this.baseUrl + '/CourseStages/GetAllCourseStages', { headers: headers })
    }

    getById(id: number): Observable<CourseStage> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<CourseStage>(this.baseUrl + '/CourseStages/GetCourseStageById/' + id, { headers: headers })
    }

    getByCourseId(courseId: number): Observable<CourseStage[]> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<CourseStage[]>(this.baseUrl + '/CourseStages/GetCourseStagesByCourseId/' + courseId, { headers: headers })
    }
    
    update(courseStage: CourseStage): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        console.log(courseStage)
        return this.http.put<any>(this.baseUrl + '/CourseStages/UpdateCourseStage', JSON.stringify(courseStage), { headers: headers })
    }

    delete(id): Observable<any> {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.delete<any>(this.baseUrl + '/CourseStages/DeleteCourseStage/' + id, { headers: headers })
    }
}