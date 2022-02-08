using System.ComponentModel.DataAnnotations;

namespace Elections.Models
{
    public class OptionToVote
    {
        [Key]
        public int Id { get; set; }
        public string CandidateOrPartyName { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
    }
}