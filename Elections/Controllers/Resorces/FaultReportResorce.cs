using Elections.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class FaultReportResorce
    {
        public FaultReportResorce()
        {
            Replies = new List<ReplyResorce>();
        }
        [Key]
        public int Id { get; set; }
        public string Despriction { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
        public bool IsOpen { get; set; }
        public Election Election { get; set; }
        public int ElectionId { get; set; }
        public Area Area { get; set; }

        public List<ReplyResorce> Replies { get; set; }
    }
}
