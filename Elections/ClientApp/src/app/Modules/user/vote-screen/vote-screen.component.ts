import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import { forkJoin } from 'rxjs';
import { UserService } from '../../../services/user.service';


@Component({
  selector: 'app-vote-screen',
  templateUrl: './vote-screen.component.html',
  styleUrls: ['./vote-screen.component.css']
})
export class VoteScreenComponent implements OnInit {

  userId;
  elections: any[];
  optionsToVote: any[];
  //voterWithElection: any[]
  voterId: number


   
  vote={
    AlreadyVoted: true,
    OptionToVoteIdNumber:0
}


  constructor(private service: ElectionService, private route: ActivatedRoute, private router: Router, private userService: UserService) {
    this.userId = userService.userId;

  //  route.params.subscribe(u => { this.userId = +u['id'];})
  }



  ngOnInit() {

    this.service.getElections(this.userId).subscribe((e: any) => { this.elections = e })
  }

  filterOpenElections() {
    return this.elections.filter(e => e.election.isOpen == true && e.alreadyVoted == false || e.election.isOpen == true && e.election.ischangeable)
  }

  getOptionsToVote() {
    var currentvoter = this.filterOpenElections().find(v => v.id == this.voterId)
    this.service.getOptionsToVote(currentvoter.election.id).subscribe((o: any) => { this.optionsToVote = o; })
  }

  submit() {
    this.service.updateVote(this.voterId, this.vote).subscribe(x => { this.router.navigate(['/user/' + this.userId + '/userarea']) })
  }

}
