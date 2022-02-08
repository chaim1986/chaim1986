import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  constructor(public userservice: UserService, private rout: ActivatedRoute) {
    rout.params.subscribe(u => { userservice.userId = +u['userid'] })
  }

  ngOnInit(): void {
  }

}
