using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class FaultResorce
    {
        public FaultResorce()
        {
            Replies = new List<ReplyResorce>();
            IsOpen = true;
        }
        public int Id { get; set; }
        public string Despriction { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
        public bool IsOpen { get; set; }
        public string Open { get { if (IsOpen) return "תלונה פתוחה"; return ""; } }
        public List<ReplyResorce> Replies { get; set; }

    }
}
