using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class ElectionResorce
    {
        public ElectionResorce()
        {
            Voters = new List<VoterResorceWithoutElection>();
            optionToVotes = new List<OptionToVoteResorce>();
            Areas = new List<AreaResorce>();
        }
        public int Id { get; set; }
        public string NameOfTheElection { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOpen { get { return checkIfOpenBool(); }   } 
        public string Open { get { return checkIfOpen(); }  }

        private string checkIfOpen()
        {
            string answer = "";
            if(StartTime<DateTime.Now && EndTime> DateTime.Now)
            {
                answer = "בחירות פתוחות להצבעה";
            }
            else if(StartTime>DateTime.Now)
            {
                answer = "בחירות עדיין לא נפתחו ";
            }
            else
            {
                answer = "בחירות נגמרו!";
            }
            return answer;
        }

        private bool checkIfOpenBool()
        {
            bool isOpen = false;
            if (StartTime < DateTime.Now && EndTime > DateTime.Now)
            {
                isOpen = true;
            }
            else if (StartTime > DateTime.Now)
            {
                isOpen = false;
            }
            else
            {
                isOpen = false;
            }
            return isOpen;
        }

        public int ManegerUserId { get; set; }
        public UserResorce userManager { get; set; }
        public bool Ischangeable { get; set; }
        public List<VoterResorceWithoutElection> Voters { get; set; }
        public List<OptionToVoteResorce> optionToVotes { get; set; }
        public List<AreaResorce> Areas { get; set; }
    }

}
