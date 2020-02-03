import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from '../_models/user.interface';
import { UsersService } from '../_services/users.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  displayedColumns: string[] = ['id', 'username', 'password', 'firstName', 'lastName', 'email', 'adress', 'phone', 'enrolments', 'points', 'roleId'];
  displayedColumnsTable: string[] = ['id', 'username', 'password', 'firstName', 'lastName', 'email', 'adress', 'phone', 'enrolments', 'points', 'roleId', "Action"];

  dataSource: MatTableDataSource<User>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private userService: UsersService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.getAllUsers()
  }

  getAllUsers() {
    this.userService.getAll().subscribe((users: User[]) => {
      this.dataSource = new MatTableDataSource(users);
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
    const dialogRef = this.dialog.open(UserDialog, {
      data: { id: id },
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getAllUsers()
    });
  }

}


@Component({
  selector: 'user-popup',
  templateUrl: 'user-popup.html',
})
export class UserDialog implements OnInit {

  displayedColumns: string[] = ['username', 'password', 'firstName', 'lastName', 'email', 'adress', 'phone', 'points', 'roleId'];

  id = 0
  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required]);
  firstName = new FormControl('', [Validators.required]);
  lastName = new FormControl('', [Validators.required]);
  email = new FormControl('', [Validators.required, Validators.email]);
  adress = new FormControl('', [Validators.required]);
  phone = new FormControl('', [Validators.required]);
  points = new FormControl('', [Validators.required]);
  roleId = new FormControl('', [Validators.required]);
  
  userFrom = new FormGroup({
    username: this.username,
    password: this.password,
    firstName: this.firstName,
    lastName: this.lastName,
    email: this.email,
    adress: this.adress,
    phone: this.phone,
    points: this.points,
    roleId: this.roleId
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UsersService) {
    this.getUserById(data.id);
  }

  ngOnInit() {
  }

  getUserById(id: number) {
    if(id > 0) {
      this.userService.getById(id).subscribe((user: User) => {
        this.id = user.id;
        this.displayedColumns.forEach(element => {
        this[element].setValue(user[element])
        });
      },
        error => {
          console.log(error)
        });
    }
    
  }


  getErrorMessage(prop) {
    return this.email.hasError('required') ? 'You must enter a value' :
      '';
  }

  create() {
    let user = {};
    user['id'] = 0;
    this.displayedColumns.forEach(element => {
      user[element] = this[element].value;
    });
    this.userService.create(user).subscribe((res) => {
      console.log(res)
    },
      error => {
        console.log(error)
      });
  }

  update() {
    let user = {};
    user['id'] = this.data.id;
    this.displayedColumns.forEach(element => {
      user[element] = this[element].value;
    });
    this.userService.update(user).subscribe((res) => {
      console.log(res)
    },
      error => {
        console.log(error)
      });
  }
}