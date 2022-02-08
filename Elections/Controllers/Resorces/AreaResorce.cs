using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class AreaResorce
    {
        public int Id { get; set; }

        public string NameOfArea { get; set; }
        public int ElectionId { get; set; }
        public List<FaultResorce> faults { get; set; }
    }
}
