import { UserService } from './../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  jsonuser: any

  userId: number
  constructor(private rout: ActivatedRoute, public auth: AuthService,private userService :UserService) {
    
   
    rout.params.subscribe(u => {
      this.userId = this.userService.userId  = +u['id']; 
    })
  }

  ngOnInit() {
  //  this.auth.user$.subscribe(u => { this.jsonuser = JSON.stringify(u); })
  }


}
