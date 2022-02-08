namespace Elections.Controllers.Resorces
{
    public class VoterResorceWithoutElection
    {
        public VoterResorceWithoutElection()
        {
            IsInspector = false;
            AlreadyVoted = false;
        }
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool AlreadyVoted { get; set; }

        public bool IsInspector { get; set; }
        public int ElectionId { get; set; }

        public int OptionToVoteIdNumber { get; set; }
    }
}