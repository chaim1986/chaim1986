import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import { user } from '../../../ifaulte';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  constructor(private service: ElectionService, private route: ActivatedRoute, private router: Router, private userService: UserService) {
    if (userService.userId)
    this.userId = userService.userId;
  //  route.params.subscribe(p => { this.userId = +p['id']; })
  }

  userDetails: user = {
    id: 0,
    firstName: "",
    lastName: "",
    phoneNumber: "",
    street: "",
    city: "",
    emailAdress: "",
    password: "",
    isManager: false
  }
  userId: number
  ngOnInit() {
    if (this.userId)
      this.service.getUserDetails(this.userId).subscribe((u: user) => { this.userDetails = u; });
  }

  submit() {
    if (this.userId) {
      this.service.updateUser(this.userId, this.userDetails).subscribe(x => { this.router.navigate(['user/'+ this.userId+ '/userarea']) })
    }
    else {
      this.service.createUser(this.userDetails).subscribe(u => { this.router.navigate(['login']) })
    }
  }

  delete() {
    this.service.deleteUser(this.userId).subscribe(x => { this.router.navigate(['/'])})

  }

}
