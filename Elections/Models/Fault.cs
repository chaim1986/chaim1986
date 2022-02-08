using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Fault
    {
        public Fault()
        {
            Replies = new List<Reply>();
            IsOpen = true;
        }
        [Key]
        public int Id { get; set; }
        public string Despriction { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
        public bool IsOpen { get; set; }
        public Election Election { get; set; }
        public Area Area { get; set; }
       
        public List<Reply> Replies { get; set; }

    }
}
