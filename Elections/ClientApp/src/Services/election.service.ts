import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { election, fault } from '../app/ifaulte';
//import { AuthHttp } from "angular2-jwt/angular2-jwt";


@Injectable({
  providedIn: 'root'
})
export class ElectionService {

  constructor(private http: HttpClient/*, private authHttp: AuthHttp*/) { }


  getElections(userid: number) {
    return this.http.get('/api/elections/GetElectionsOfUser/' + userid, this.getOptions() 

    );
  }

  getElectionsForManager() {
    return this.http.get('/api/elections', this.getOptions()  )
  }

  getElection(electionid: number) {
    return this.http.get('api/elections/' + electionid, this.getOptions())
  }
  createElection(election: election) {
    return this.http.post('api/elections', election)
  }
  apdateElection(electionid: number, election: election) {
    return this.http.put('api/elections/' + electionid, election, this.getOptions())
  }

  getUserDetails(userid: number) {
    return this.http.get('/api/users/' + userid, this.getOptions());
  }

  createUser(user: any) {
    return this.http.post('/api/users', user);
  }

  updateUser(userId: number, userdetails) {
    return this.http.put('/api/users/' + userId, userdetails);
  }

  deleteUser(userid: number) {
    return this.http.delete('/api/users/' + userid);
  }

  faulteReport(faulte) {
    return this.http.post('/api/faults', faulte);
  }

  faulteReportWithReplay(fault: fault, id: number) {
    return this.http.put('/api/faults/' +id, fault);
  }

  getAreaOfUser(userId: number, electionId: number) {
    return this.http.get('/api/area?electionId=' + electionId + '&userId=' + userId)
  }

  getOptionsToVote(electionId: number) {
    return this.http.get('/api/option/GetOptionsOfElection/' + electionId)
  }

  updateVote(id: number, vote: any) {
    return this.http.put('/api/voters/SetVote/' + id, vote)
  }

  getFaultes(userId: number) {
    return this.http.get('/api/fualts/GetFaultsOfInspector/' + userId)
  }

  login(email: any) {
    return this.http.post<{ token: string, userId: number, isManager: boolean }>('/auth', email)
  }

  getFaultesForInspector(id: number) {
    return this.http.get('/api/faults/GetFaultsOfInspector/' + id)
  }

  getOptions() {

    //var headers: HttpHeaders = new HttpHeaders();

     var headers=  {
       Authorization: "Bearer " + localStorage.getItem("token")
    }

    return { headers };
  }

  
}
