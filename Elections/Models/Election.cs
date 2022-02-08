using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Elections.Models
{
    public class Election
    {
        public Election()
        {
            Voters = new List<Voter>();
            optionToVotes = new List<OptionToVote>();
            Areas = new List<Area>();
            Faults = new List<Fault>();
        }
        [Key]
        public int Id { get; set; }
        public string NameOfTheElection { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOpen { get; set; }
        public int ManegerUserId { get; set; }
        public User userManager { get; set; }
        public bool Ischangeable { get; set; }
        public List<Voter> Voters { get; set; }
        public List<OptionToVote> optionToVotes { get; set; }
        public List<Area> Areas { get; set; }
        public List<Fault> Faults { get; set; }
    }
}