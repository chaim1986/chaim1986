

export interface user {

  id: number,
  firstName: string,
  lastName: string,
  phoneNumber: string,
  emailAdress: string,
  city: string,
  street: string,
  password: string,
  isManager: boolean
}

export interface fault {
  id: number,
  despriction: string,
  userId: number,
  areaId: number,
  isOpen: boolean,
  open: string,
  replies: replay[]

  
  


}

export interface replay {
  Content: string,
  UserInspectorId: number,
  FaultId: number,
}

export interface election {
  id: number,
  nameOfTheElection: string,
  startTime: Date,
  endTime: Date,
  open: string,
  manegerUserId: number,
  ischangeable: boolean,
  optionToVotes: optionToVote[],
  areas: area[],
  voters: voter[]

}

export interface voter {
  id: number,
  phoneNumber: string,
  alreadyVoted: boolean,
  isInspector: boolean,
  electionId: number,
  optionToVoteIdNumber: number
}

export interface optionToVote {
  id: number,
  candidateOrPartyName: string,
  electionId: number
}

export interface area {
  id: number,
  nameOfArea: string,
  electionId: number,
  faults: any[]
}


