import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { Routes, RouterModule } from '@angular/router';
import { UserAreaComponent } from './user-area/user-area.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { UserDetailsComponent } from './user-details/user-details.component';
import { FaultReportComponent } from './fault-report/fault-report.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { VoteScreenComponent } from './vote-screen/vote-screen.component';
import { ElectionService } from '../../../Services/election.service';
import { NavbarUserComponent } from './navbar-user/navbar-user.component';



const routes: Routes = [
  {
    path: ':id', component: UserComponent,
    children: [
      { path: 'userarea', component: UserAreaComponent },
      { path: 'userdetails', component: UserDetailsComponent },
      { path: 'userreport', component: FaultReportComponent },
      { path: 'uservoterscreen', component: VoteScreenComponent },
    ]
  },

  

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class userRoutingModule{ }


@NgModule({
  declarations: [UserComponent, UserAreaComponent, UserDetailsComponent, FaultReportComponent, VoteScreenComponent, NavbarUserComponent],
  imports: [
    CKEditorModule,
    CommonModule,
    HttpClientModule,
    FormsModule, userRoutingModule
  ],
  //bootstrap: [UserComponent]

})
export class UserModule { }
