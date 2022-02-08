import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import { election } from '../../../ifaulte';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-manager-control',
  templateUrl: './manager-control.component.html',
  styleUrls: ['./manager-control.component.css']
})
export class ManagerControlComponent implements OnInit {
  managerId: number
  constructor(private apiService: ElectionService, private router: Router, private user: UserService) {
    this.managerId = user.userId;
  }
  elections: election[]
  ngOnInit(): void {

    this.apiService.getElectionsForManager().subscribe((e: election[]) => { this.elections = e; })
  }

  updateElection(electionId: number) {
    this.router.navigate(['manager/' + this.managerId + '/createElection/' + electionId])
  }
}
