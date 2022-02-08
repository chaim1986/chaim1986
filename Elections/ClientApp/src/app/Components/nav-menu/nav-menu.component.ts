import { Component } from '@angular/core';
 import { AuthService } from '@auth0/auth0-angular';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(public AuthService: AuthService, public userservice: UserService) {
    if (localStorage.getItem("token")) {
      userservice.conected = true;
    }
  }

  //conected: boolean

  

  logOut() {
    localStorage.removeItem("token");
    this.userservice.conected = false;
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
