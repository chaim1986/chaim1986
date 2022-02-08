import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ElectionService } from '../../Services/election.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  u: any = {
    emailAdress:"",
    password:""
  }
  userId: number
  loginFaild: boolean

  constructor(private electionService: ElectionService, private router: Router, public userservice: UserService) { }


  ngOnInit(): void {
  }

  register() {
    this.router.navigate(['userdetails'])
  }

  login() {
    this.electionService.login(this.u).subscribe(
      res => {
        localStorage.setItem("token", res.token);

        this.userservice.conected = true;

        if (res.isManager) {
          this.router.navigate(['manager/' + res.userId])
        }
        else {
          this.router.navigate(['user/' + res.userId + '/userarea'])
        }
      }, err => {
        this.loginFaild = true;
        console.log('err', err)
      }
    )
  }


  
}
