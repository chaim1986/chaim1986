import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { InspectorComponent } from './inspector.component';
import { InpectorScreenComponent } from './inpector-screen/inpector-screen.component';
import { InspectorFaultsComponent } from './inspector-faults/inspector-faults.component';
import { MatDialogModule, } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { ModalModule } from 'ngb-modal';
import { DialogModule } from 'primeng/dialog';
import { InspectorFaults2Component } from './inspector-faults2/inspector-faults2.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';


const routes: Routes = [
  {
    path: ':id', component: InspectorComponent, children: [
      { path: 'inspectorscreenarea', component: InpectorScreenComponent },
      { path: 'inspectorfaults', component: InspectorFaultsComponent },
      { path: 'inspectorfaults2', component: InspectorFaults2Component },
    ]
  },
];

@NgModule({
  declarations: [InspectorComponent, InpectorScreenComponent,InspectorFaultsComponent, InspectorFaults2Component],
  // entryComponents: [],
  imports: [
    CKEditorModule,
    MatDialogModule,
    CommonModule,
    ModalModule,
    FormsModule,
    DialogModule,
    RouterModule.forChild(routes)
  ]
})
export class InspectorModule { }
