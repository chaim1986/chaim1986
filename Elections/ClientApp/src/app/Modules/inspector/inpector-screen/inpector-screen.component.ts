import { Component, OnInit,Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../../Services/election.service';
import { MatDialog } from '@angular/material/dialog';
import { InspectorFaultsComponent } from '../inspector-faults/inspector-faults.component';
import { ModalManager } from 'ngb-modal';
import { fault} from '../../../ifaulte';
import { UserService } from '../../../services/user.service';
import { User } from 'oidc-client';


@Component({
  selector: 'app-inpector-screen',
  templateUrl: './inpector-screen.component.html',
  styleUrls: ['./inpector-screen.component.css']
})
export class InpectorScreenComponent implements OnInit {
  private modalRef;
  userId: number
  faults: any
  fault: fault;
  user: any;
  constructor(private service: ElectionService, private route: ActivatedRoute, private router: Router,
    public dialog: MatDialog, private modalService: ModalManager, private userservice: UserService) {
    this.userId = userservice.userId;
  }

  ngOnInit() {
    this.service.getFaultesForInspector(this.userId).subscribe(f => { this.faults = f; })
    this.getNameOfReplayes();
    
  }

  getNameOfReplayes() {

  }

  test1(fault: fault) {
    this.fault = fault;
    this.getUser(fault.userId)
    this.showDialog();
  }
  getUser(id: number) {
    this.service.getUserDetails(id).subscribe(u => { this.user = u; })
  }
  display: boolean = false;

  showDialog() {
    this.display = true;
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(InspectorFaultsComponent, {
      data: { fault: this.fault },
      height: '1000px',
      width: '1000px',
      hasBackdrop: true,
      position: {
        top: '0',
        left: '0',

      }
    });
  }
  openModal() {
    this.modalRef = this.modalService.open(InspectorFaultsComponent, {
      size: "md",
      modalClass: 'mymodal',
      hideCloseButton: false,
      centered: false,
      backdrop: true,
      animation: true,
      keyboard: false,
      closeOnOutsideClick: true,
      backdropClass: "modal-backdrop"
    })
  }
  closeModal() {
    this.modalService.close(this.modalRef);
    //or this.modalRef.close();
  }


}
