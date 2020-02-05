import { Injectable } from '@angular/core';
import { NotificationService } from '../_services/notification.service';
//import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable()
export class AuthService {
  constructor(
    public notificationService: NotificationService) {}

  public isAuthenticated(): boolean {

    const currentUser = localStorage.getItem('user');
    if(currentUser == null) {
      this.notificationService.openSnackBar('Please Log In')
    }
    return currentUser != null 
  }

  public isAdmin(): boolean {

    const currentUser = JSON.parse(localStorage.getItem('user'));
    console.log(currentUser == null && currentUser.roleId != 1)
    if(currentUser == null || currentUser.roleId != 1) {
      this.notificationService.openSnackBar('You are not admin')
      return false
    } 

    
    return currentUser != null && currentUser.roleId == 1
  }
}