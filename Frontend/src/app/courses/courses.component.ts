import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  courses = [
    {
      id: '1',
      title: 'React-native introduction',
      url: ''
    },
    {
      id: '2',
      title: 'Angular8 Advanced',
      url: ''
    },
    {
      id: '3',
      title: 'Smecherie',
      url: ''
    }
  ];

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  goTo(id) {
    this.router.navigate(['/course/ ' + id]);
  }

}
