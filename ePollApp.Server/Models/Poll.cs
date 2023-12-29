namespace ePollApp.Server.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PollOption> Options { get; set; }

    }
}
