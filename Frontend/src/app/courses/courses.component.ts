import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Course } from '../_models/course.interface';
import { CoursesService } from '../_services/courses.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})

export class CoursesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'details', 'tags'];
  displayedColumnsTable: string[] = [... this.displayedColumns, "Action"];

  dataSource: MatTableDataSource<Course>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private courseService: CoursesService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.getAllCourses()
  }

  getAllCourses() {
    this.courseService.getAll().subscribe((courses: Course[]) => {
      this.dataSource = new MatTableDataSource(courses);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    },
      error => {
        console.log(error)
        // this.notificationService.handleError(error);
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

    dialogRef.afterClosed().subscribe(_ => {
      this.getAllCourses()
    });
  }

  delete(id) {
    this.courseService.delete(id).subscribe((res) => {
      console.log(res)
    },
      error => {
        console.log(error)
      });
  }

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

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private courseService: CoursesService) {
    this.getCourseById(data.id);
  }

  ngOnInit() {
  }

  getCourseById(id: number) {
    if(id > 0) {
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
    this.courseService.create(course).subscribe((res) => {
      console.log(res)
    },
      error => {
        console.log(error)
      });
  }

  update() {
    let course = {};
    course['id'] = this.data.id;
    this.displayedColumns.forEach(element => {
      course[element] = this[element].value;
    });
    this.courseService.update(course).subscribe((res) => {
      console.log(res)
    },
      error => {
        console.log(error)
      });
  }
}