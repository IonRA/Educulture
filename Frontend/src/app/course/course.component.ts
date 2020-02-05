import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { CoursesService } from '../_services/courses.service';
import { MatDialog } from '@angular/material';
import { NotificationService } from '../_services/notification.service';
import { Course } from '../_models/course.interface';
import { CourseStagesService } from '../_services/course-stages.service';
import { CourseStage } from '../_models/course-stage.interface';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { EnrollmentsService } from '../_services/enrollments.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  
  id;
  course: Course;

  courseStages: CourseStage[] = [];
  numberOfStages: number = 0;

  
  currentUser = JSON.parse(localStorage.getItem('user'));

  constructor(private router: Router,
    private route: ActivatedRoute,
    private courseService: CoursesService,
    public dialog: MatDialog,
    public notificationService: NotificationService,
    public courseStagesService: CourseStagesService,
    public enrollmentsService: EnrollmentsService
  ) {
  }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.courseService.getById(this.id).subscribe((course: Course) => {
      this.course = course;
      this.getAllStages();
      console.log(this.currentUser.id, this.course.userId)
    },
    error => {
      console.log(error)
    });

  }

  getAllStages() {
    this.courseStagesService.getByCourseId(this.id).subscribe((courseStages: CourseStage[]) => {
      this.courseStages = courseStages;
      this.numberOfStages = this.courseStages.length;
    },
    error => {
      console.log(error)
    });
  }

  step = 0;

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  numbe

  
  stageName = new FormControl('', [Validators.required]);
  stageText = new FormControl('', [Validators.required]);

  form = new FormGroup({
    stageName: this.stageName,
    stageText: this.stageText,
  });

  createStage() {
    let stage = {
      id: 0,
      name: this.stageName.value,
      text: this.stageText.value,
      courseId: this.id
    }
    this.courseStagesService.create(stage).subscribe((res) => {
      this.getAllStages();
      this.notificationService.openSnackBar('Succesful Create')
    },
      error => {
        console.log(error)
      });
  }


  enroll() {
    let enrollment = {
      id: 0,
      userID: this.currentUser.id,
      courseID: this.course.id,
      createdOn: "2020-02-05T09:01:03.467Z"
    }
    this.enrollmentsService.create(enrollment).subscribe((res) => {
      this.notificationService.openSnackBar('Succesful Enrollment or already Enrolled')
    },
      error => {
        console.log(error)
      });
  }
}
