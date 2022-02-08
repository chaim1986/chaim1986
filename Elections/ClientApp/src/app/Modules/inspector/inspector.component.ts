import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../Services/election.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-inspector',
  templateUrl: './inspector.component.html',
  styleUrls: ['./inspector.component.css']
})
export class InspectorComponent implements OnInit {
  userId;
  user;
  public visibleShow: boolean = true
  constructor(private router: Router, private userService: UserService, private route: ActivatedRoute, private electionService: ElectionService) {
    route.params.subscribe(u => { this.userId = userService.userId = +u['id']; })
  }

  ngOnInit() {
    this.electionService.getUserDetails(this.userId).subscribe(u => { this.user = u; })
    
  }
  showFaultArea() {
    this.visibleShow = false;
    this.router.navigate(['inspector/' + this.userId+ '/inspectorscreenarea'])
  }

}
