import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import { election, optionToVote, voter } from '../../../ifaulte';
import { UserService } from '../../../services/user.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-create-election',
  templateUrl: './create-election.component.html',
  styleUrls: ['./create-election.component.css']
})
export class CreateElectionComponent implements OnInit {
  data: any;
  fileOfVoters: File | null = null;
  electionId: number
  election: election = {
    id: 0,
    nameOfTheElection: "",
    startTime: new Date(""),
    endTime: new Date(""),
    ischangeable: false,
    manegerUserId: 0,
    open: "",
    optionToVotes: [],
    areas: [],
    voters: []
    

  }

  managerId: number
  displayOption: boolean = false;
  displayArea: boolean = false;
  displaylist: boolean = false;
 

  constructor(private router: Router, private userservice: UserService, private rout: ActivatedRoute, private service: ElectionService) {
    this.managerId = userservice.userId;
    rout.params.subscribe(e => { this.electionId = +e['electionid']; })
  }

  ngOnInit(): void {
    if (this.electionId)
    this.service.getElection(this.electionId).subscribe((e: election) => { this.election = e; })
  }
  showDialogOfOptions() {
    this.displayOption = true;
  }

  showDialogOfArea() {
    this.displayArea = true;
  }

  addOption() {
    this.election.optionToVotes.push({
      candidateOrPartyName: '',
      electionId: 0,
      id: 0
    })
  }

  remove(index: number) {
    this.election.optionToVotes.splice(index, 1);
  }

  addArea() {
    this.election.areas.push({
      electionId: 0,
      faults: [],
      id: 0,
      nameOfArea:''

    })
  }

  removeArea(index: number) {
    this.election.areas.splice(index, 1);
  }

  showAddListOfVoters() {
    document.getElementById('list').style.display = "";
  }

  addListOfVoters(evt: any) {
    const target: DataTransfer = <DataTransfer>(evt.target);
    const reader: FileReader = new FileReader();

    reader.onload = (e: any) => {
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];
      this.data = (XLSX.utils.sheet_to_json(ws, { header: 1 }))

      for (var i = 0; i < this.data.length; i++) {
        this.election.voters.push({
          phoneNumber:  this.data[i][0],
          alreadyVoted: false,
          electionId: 0,
          id: 0,
          isInspector: false,
          optionToVoteIdNumber: 0

        })
        console.log(this.election.voters)
      }      
    }


    reader.readAsBinaryString(target.files[0]);

    
  }

  closeDialog() {
    this.displayArea = false;
    this.displayOption = false;
    this.displaylist = false;
  }


  showlistOfVoters() {
    this.displaylist = true;
  }

  submit() {

    

    if (this.electionId) {
      this.service.apdateElection(this.electionId, this.election).subscribe(e => { })
    }
    else {
      this.election.manegerUserId = this.managerId;
      this.service.createElection(this.election).subscribe(e => {  })
    }

    this.router.navigate(['manager/' + this.managerId + '/managerControlArea'])
  }
}
