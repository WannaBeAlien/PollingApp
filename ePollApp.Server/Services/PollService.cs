// Services/PollService.cs
using ePollApp.Server.Models;
using ePollApp.Server.Services;

public class PollService : IPollService
{
    private readonly List<Poll> _polls = [];

    public PollService()
    {
        // Initialize with a default poll if there are no polls yet
        if (_polls.Count == 0)
        {
            AddDefaultPoll();
        }
    }
    private void AddDefaultPoll()
    {
        var defaultPoll = new Poll
        {
            Title = "Favorite Programming Language",
            Options = new List<PollOption>
            {
                new PollOption { Title = "JavaScript", Votes = 0 },
                new PollOption { Title = "Python", Votes = 0 },
                new PollOption { Title = "Java", Votes = 0 },
                new PollOption { Title = "C#", Votes = 0 },
                new PollOption { Title = "Ruby", Votes = 0 }
            }
        };

        AddPoll(defaultPoll);
    }

    public IEnumerable<Poll> GetPolls()
    {
        return _polls;
    }

    public Poll GetPollById(int id)
    {
        return _polls.FirstOrDefault(p => p.Id == id);
    }

    public Poll AddPoll(Poll poll)
    {
        poll.Id = _polls.Count + 1;
        _polls.Add(poll);
        return poll;
    }

    public Poll Vote(int pollId, int optionId)
    {
        var poll = _polls.FirstOrDefault(p => p.Id == pollId);
        if (poll == null)
        {
            return null;
        }

       var option = poll.Options.FirstOrDefault(o => o.Id == optionId);
        if (option != null)
        {
            option.Votes++;
        }

        return poll;
    }

    // Add other method implementations as needed
}
