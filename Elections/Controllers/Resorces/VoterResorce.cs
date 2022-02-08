using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class VoterResorce
    {
        public VoterResorce()
        {
            IsInspector = false;
            AlreadyVoted = false;
        }
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool AlreadyVoted { get; set; }

        public bool IsInspector { get; set; }
        public ElectionResorce Election { get; set; }
        public int ElectionId { get; set; }

        public int OptionToVoteIdNumber { get; set; }

    }
}
