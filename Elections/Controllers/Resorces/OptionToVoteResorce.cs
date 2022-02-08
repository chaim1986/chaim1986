using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class OptionToVoteResorce
    {
        public int Id { get; set; }
        public string CandidateOrPartyName { get; set; }
        public int ElectionId { get; set; }
    }
}
