import { Component, OnInit, Input} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { UserService } from '../../../services/user.service';


@Component({
  selector: 'app-fault-report',
  templateUrl: './fault-report.component.html',
  styleUrls: ['./fault-report.component.css'],

})
export class FaultReportComponent implements OnInit {

  constructor(private service: ElectionService, private route: ActivatedRoute, private router: Router, private userService: UserService) {
    this.fullReport.userId = userService.userId;

  // route.params.subscribe(p => { this.fullReport.userId = +p['id']; })
  }
  fullReport: any = {
    userId:0,
    areaId: 0,
    despriction: "בבקשה כתוב כאן את התקלה בקצרה!!",



  }
;
  electionId: number
  elections: any
  public Editor = ClassicEditor;



  ngOnInit() {
    console.log(this.fullReport);

    this.service.getElections(this.fullReport.userId).subscribe(e => { this.elections = e; })
  }

  makeReport(elecId) {
    this.electionId = elecId;

    this.service.getAreaOfUser(this.fullReport.userId, this.electionId).subscribe((a: any) => { this.fullReport.areaId = a.id;})
  }

  report() {
    this.service.faulteReport(this.fullReport).subscribe(() => { alert("הודעתך נשלחה בהצלחה"), this.router.navigate(['/user/' + this.fullReport.userId +  '/userarea']); })
  }

}
