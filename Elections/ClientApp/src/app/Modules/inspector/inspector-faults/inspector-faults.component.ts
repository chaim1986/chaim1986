import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-inspector-faults',
  templateUrl: './inspector-faults.component.html',
  styleUrls: ['./inspector-faults.component.css']
})
export class InspectorFaultsComponent implements OnInit {
   @Input() fault : any;
  constructor(public dialogRef: MatDialogRef<InspectorFaultsComponent>, @Inject(MAT_DIALOG_DATA) public data: { fault: any }) {
    console.log(this.fault);
    console.log(this.fault);
    
  }
  
  ngOnInit(): void {
    console.log(this.fault);
  }
  closeDialog() {
    this.dialogRef.close('Pizza!');
  }
  save() {

  }
}
