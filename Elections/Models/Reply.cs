using System.ComponentModel.DataAnnotations;

namespace Elections.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserInspectorId { get; set; }
        public User UserInspector { get; set; }
        public int FaultId { get; set; }
        public Fault Fault { get; set; }
    }
}