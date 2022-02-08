import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerComponent } from './manager.component';
import { RouterModule, Routes } from '@angular/router';
import { ManagerControlComponent } from './manager-control/manager-control.component';
import { CreateElectionComponent } from './create-election/create-election.component';
import { FormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { ImportVotersComponent } from './import-voters/import-voters.component';

const routs: Routes = [
  {
    path: ':userid', component: ManagerComponent, children: [
      { path: 'managerControlArea', component: ManagerControlComponent },
      { path: 'createElection/:electionid', component: CreateElectionComponent },
      { path: 'createElection', component: CreateElectionComponent },
      { path: 'importvoters', component: ImportVotersComponent }
    ]
  }
]

@NgModule({
  declarations: [
    ManagerComponent,
    ManagerControlComponent,
    CreateElectionComponent,
    ImportVotersComponent
  ],
  imports: [
    DialogModule,
    CommonModule,
    FormsModule,
    RouterModule.forChild(routs)
  ],
  exports: [RouterModule],

})
export class ManagerModule { }
