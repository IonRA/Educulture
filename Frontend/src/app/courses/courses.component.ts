import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Course } from '../_models/course.interface';
import { CoursesService } from '../_services/courses.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';
import { NotificationService } from '../_services/notification.service';
import { EnrollmentsService } from '../_services/enrollments.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})

export class CoursesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'details', 'tags'];
  displayedColumnsTable: string[] = [... this.displayedColumns, "Action"];
  currentUser = JSON.parse(localStorage.getItem('user'));
  dataSource: MatTableDataSource<Course>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private courseService: CoursesService,
    public dialog: MatDialog,
    private router: Router,
    public notificationService: NotificationService,
    public enrollmentsService: EnrollmentsService
  ) { }

  ngOnInit() {
    if (this.currentUser.roleId == 1) {
      this.getAllCourses();
    } else if (this.currentUser.roleId == 2) {
      this.getAllCreatedByUserId();
      this.getAllEnrolledByUserId();
      this.getAllNotEnrolledByUserId();
    }

  }

  courses: Course[]

  enrolledCourses: Course[]
  notEnrolledCourses: Course[]
  createdByUserCourses: Course[]

  getAllCourses() {
    this.courseService.getAll().subscribe((courses: Course[]) => {
      this.courses = courses
      this.dataSource = new MatTableDataSource(courses);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    },
      error => {
        console.log(error)
        // this.notificationService.handleError(error);
      });
  }

  getAllCreatedByUserId() {
    this.courseService.getAllCreatedByUserId(this.currentUser.id).subscribe((courses: Course[]) => {
      this.createdByUserCourses = courses
    },
      error => {
        console.log(error)
      });
  }

  getAllEnrolledByUserId() {
    this.courseService.getAllEnrolledByUserId(this.currentUser.id).subscribe((courses: Course[]) => {
      this.enrolledCourses = courses
    },
      error => {
        console.log(error)
      });
  }

  getAllNotEnrolledByUserId() {
    this.courseService.getAllNotEnrolledByUserId(this.currentUser.id).subscribe((courses: Course[]) => {
      this.notEnrolledCourses = courses
    },
      error => {
        console.log(error)
      });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openDialog(id = 0) {
    const dialogRef = this.dialog.open(CourseDialog, {
      data: { id: id },
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(res => {
      if (res.method == "create") {

        res.course.userId = this.currentUser.id;
        this.courseService.create(res.course).subscribe((res) => {
          if (this.currentUser.roleId == 1) {
            this.getAllCourses();
          } else if (this.currentUser.roleId == 2) {
            this.getAllCreatedByUserId();
            this.getAllEnrolledByUserId();
            this.getAllNotEnrolledByUserId();
          }
          this.notificationService.openSnackBar('Succesful Create')
        },
          error => {
            console.log(error)
          });
      } else if (res.method == "update") {
        this.courseService.update(res.course).subscribe((res) => {
          this.getAllCourses();
          this.notificationService.openSnackBar('Succesful Update')
        },
          error => {
            console.log(error)
          });
      }
    });
  }

  delete(id) {
    this.courseService.delete(id).subscribe((res) => {
      if (this.currentUser.roleId == 1) {
        this.getAllCourses();
      } else if (this.currentUser.roleId == 2) {
        this.getAllCreatedByUserId();
        this.getAllEnrolledByUserId();
        this.getAllNotEnrolledByUserId();
      }
      this.notificationService.openSnackBar('Succesful Delete')
    },
      error => {
        console.log(error)
      });
  }

  goTo(id) {
    this.router.navigate(['/course/ ' + id]);
  }

  enroll(courseId: number) {
    let enrollment = {
      id: 0,
      userID: this.currentUser.id,
      courseID: courseId,
      createdOn: "2020-02-05T09:01:03.467Z"
    }
    this.enrollmentsService.create(enrollment).subscribe((res) => {
      this.getAllEnrolledByUserId();
      this.getAllNotEnrolledByUserId();
      this.notificationService.openSnackBar('Succesful Enrollment')
    },
      error => {
        console.log(error)
      });
  }

  // unenroll(courseId: number) {
  //   this.enrollmentsService.delete(courseId).subscribe((res) => {
  //     this.getAllEnrolledByUserId();
  //     this.getAllNotEnrolledByUserId();
  //     this.notificationService.openSnackBar('Succesful Enrollment')
  //   },
  //     error => {
  //       console.log(error)
  //     });
  // }

  

}


@Component({
  selector: 'course-popup',
  templateUrl: 'course-popup.html',
})
export class CourseDialog implements OnInit {

  displayedColumns: string[] = ['name', 'details', 'tags'];

  id = 0
  name = new FormControl('', [Validators.required]);
  details = new FormControl('', [Validators.required]);
  tags = new FormControl('', [Validators.required]);

  form = new FormGroup({
    name: this.name,
    details: this.details,
    tags: this.tags
  });

  constructor(
    private dialogRef: MatDialogRef<CourseDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private courseService: CoursesService) {
    this.getCourseById(data.id);
  }

  ngOnInit() {
  }

  getCourseById(id: number) {
    if (id > 0) {
      this.courseService.getById(id).subscribe((course: Course) => {
        this.id = course.id;
        this.displayedColumns.forEach(element => {
          this[element].setValue(course[element])
        });
      },
        error => {
          console.log(error)
        });
    }

  }


  getErrorMessage(prop) {
    // return this.email.hasError('required') ? 'You must enter a value' :
    //   '';
  }

  create() {
    let course = {};
    course['id'] = 0;
    this.displayedColumns.forEach(element => {
      course[element] = this[element].value;
    });

    this.dialogRef.close({ method: 'create', course: course });
  }

  update() {
    let course = {};
    course['id'] = this.data.id;
    this.displayedColumns.forEach(element => {
      course[element] = this[element].value;
    });

    this.dialogRef.close({ method: 'update', course: course });
  }
}