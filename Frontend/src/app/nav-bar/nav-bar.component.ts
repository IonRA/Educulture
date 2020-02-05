import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from '../_services/users.service';
import { User } from '../_models/user.interface';
import { NotificationService } from '../_services/notification.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  constructor(public dialog: MatDialog,
    private userService: UsersService,
    private router: Router,
    public notificationService: NotificationService) { }

  ngOnInit() {
    let supposedUser = JSON.parse(localStorage.getItem('user'));
    if(supposedUser) {
      this.userService.login(supposedUser.username, supposedUser.password).subscribe(user => {
        localStorage.setItem("user", JSON.stringify(user));
        this.currentUser = user;
        this.router.navigate(["/"]);
      }, err => {
        console.log(err)
        localStorage.removeItem('user')
      });
    }
    
  }

  currentUser: User = null;

  openDialog(dialogName: string) {
    let dialogRef;
    if (dialogName === "login") {
      dialogRef = this.dialog.open(LogInDialog, {
        width: '450px'
      });
    } else {
      dialogRef = this.dialog.open(SignUpDialog, {
        width: '450px'
      });
    }

    dialogRef.afterClosed().subscribe(result => {

    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.method == "login") {
        this.userService.login(result.username, result.password).subscribe(user => {
          localStorage.setItem("user", JSON.stringify(user));
          this.currentUser = user;
          this.router.navigate(["/"]);
          this.notificationService.openSnackBar('Succesful Log In', 'Close');
        }, err => {
          this.notificationService.openSnackBar('Wrong username or password', 'Close');
          console.log(err)
        });
      } else if (result.method == "signup") {
        this.userService.create(result.user).subscribe(user => {
          localStorage.setItem("user", JSON.stringify(user));
          this.currentUser = user;
          this.router.navigate(["/"]);
          this.notificationService.openSnackBar('Succesful Sign Up', 'Close');
        }, err => {
          console.log(err)
        });
      }
    });
  }

  goTo(address) {
    this.router.navigate(['/' + address]);
  }

  logout() {
    localStorage.removeItem("user");
    this.router.navigate(["/"]);
    this.notificationService.openSnackBar('Succesful Log Out', 'Close');
    this.currentUser = null;
  }

}

@Component({
  selector: 'log-in-dialog',
  templateUrl: 'log-in-dialog.html',
})
export class LogInDialog {
  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required]);

  getEmailErrorMessage() {
    return this.username.hasError('required') ? 'You must enter a value' :
      '';
  }

  getPasswordErrorMessage() {
    return this.password.hasError('required') ? 'You must enter a value' :
      '';
  }
}

@Component({
  selector: 'sign-up-dialog',
  templateUrl: 'sign-up-dialog.html',
})
export class SignUpDialog {

  displayedColumns: string[] = ['username', 'firstName', 'lastName', 'email', 'adress', 'phone', 'points', 'roleId'];

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
  passwordCheck = new FormControl('', [Validators.required]);

  form = new FormGroup({
    username: this.username,
    password: this.password,
    firstName: this.firstName,
    lastName: this.lastName,
    email: this.email,
    adress: this.adress,
    phone: this.phone,
    points: this.points,
    roleId: this.roleId,
    
    passwordCheck: this.passwordCheck
  });

  constructor(
    private dialogRef: MatDialogRef<SignUpDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  getEmailErrorMessage() {
    return this.email.hasError('required') ? 'You must enter a value' :
      this.email.hasError('email') ? 'Not a valid email' :
        '';
  }

  getPasswordErrorMessage() {
    return this.password.hasError('required') ? 'You must enter a value' :
      '';
  }

  getPasswordCheckErrorMessage() {
    return this.passwordCheck.hasError('required') ? 'You must enter a value' :
      this.passwordCheck.hasError('notMatched') ? 'Passwords do not match' :
        '';
  }

  equalPasswords(): boolean {

    const matched: boolean = this.password.value === this.passwordCheck.value;

    if (matched) {
      this.form.controls.passwordCheck.setErrors(null);
    } else {
      this.form.controls.passwordCheck.setErrors({
        notMatched: true
      });
    }

    return matched;
  }

  create() {
    let user = {};
    user['id'] = 0;
    user['password'] = this.password.value;
    this.displayedColumns.forEach(element => {
      user[element] = this[element].value;
    });

    this.dialogRef.close({ method: 'signup', user: user });
  }
}