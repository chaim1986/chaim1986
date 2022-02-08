using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Elections.Models
{
    public class Area
    {
        public Area()
        {
            faults = new List<Fault>();
        }
        [Key]
        public int Id { get; set; }

        public string NameOfArea { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
        public List<Fault> faults { get; set; }
    }
}