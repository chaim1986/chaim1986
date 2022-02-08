import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '@auth0/auth0-angular';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ElectionService } from '../../../../Services/election.service';
import { fault, replay } from '../../../ifaulte';
import { UserService } from '../../../services/user.service';
import { InspectorComponent } from '../inspector.component';


@Component({
  selector: 'app-inspector-faults2',
  templateUrl: './inspector-faults2.component.html',
  styleUrls: ['./inspector-faults2.component.css']
})
export class InspectorFaults2Component implements OnInit {
  @Input() userId: number = 0;
  @Input() fault: fault = {
    id: 0, despriction: "", userId: 0, areaId: 0,  isOpen: true, open: "", replies: []
  }
  @Input() user: any
  public Editor = ClassicEditor;
  // faultWithReplay: fault = this.fault
  visibleReplay: boolean = true;


  replay: replay = { Content: "",  FaultId: 0,  UserInspectorId:0 }
  visible: boolean = false;

  constructor(private service: ElectionService, private router: Router, private inspector: InspectorComponent) {    
 }



  ngOnInit(): void {
  }

  getInspector(id: number) {
    this.service.getUserDetails(id).subscribe((u: any) => { return u.firstName })
  }

  showEditor() {
    this.visible = !this.visible;
  }

  insertReplay() {
    this.replay.UserInspectorId = this.userId
    this.replay.FaultId = this.fault.id
    this.fault.replies.push(this.replay)

    this.service.faulteReportWithReplay(this.fault, this.fault.id).subscribe(f => { this.inspector.visibleShow = true, this.router.navigate(['/inspector/' + this.userId]) })
  }

}
