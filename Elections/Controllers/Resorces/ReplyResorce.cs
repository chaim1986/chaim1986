using Elections.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class ReplyResorce
    {

       
       
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserInspectorId { get; set; }
        public int FaultId { get; set; }
        
    }
}
