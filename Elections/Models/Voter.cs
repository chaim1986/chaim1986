using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Voter
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool AlreadyVoted { get; set; }

        public bool IsInspector { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
        public int OptionToVoteIdNumber { get; set; }
    }
}
