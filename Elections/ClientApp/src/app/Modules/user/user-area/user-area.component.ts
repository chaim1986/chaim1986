import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import { election, user } from '../../../ifaulte';
import { Observable, observable } from 'rxjs';
import { of } from 'rxjs';

@Component({
  selector: 'app-user-area',
  templateUrl: './user-area.component.html',
  styleUrls: ['./user-area.component.css']
})
export class UserAreaComponent implements OnInit {

  constructor(private service: ElectionService, private router: Router, private route: ActivatedRoute, private userService: UserService) {
    this.userId = userService.userId;
    // route.params.subscribe(u => { this.userId = +u['id']; });
  }

  elections: any[] = [];
  userId: any
  user: user
  isInspector: boolean = false;
  

  inspector() {
    this.router.navigate(['inspector/' + this.userId ])

  }

  ngOnInit() {


    this.service.getElections(this.userId).subscribe((e: any) => {
      this.elections = e;
      this.checkIfInspector();
    })

    this.service.getUserDetails(this.userId).subscribe((u: user) => { this.user = u; })





  }
  
    checkIfInspector() {

      for (var i = 0; i < this.elections.length; i++) {
        if (this.elections[i].isInspector) {
          this.isInspector = true
        }
      }

     



    }

    
  

}
