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
            Id = 0,
            Title = "Favorite Programming Language",
            Options = new List<PollOption>
            {
                new PollOption {Id = 0, Title = "JavaScript", Votes = 0 },
                new PollOption {Id = 1, Title = "Python", Votes = 0 },
                new PollOption {Id = 2, Title = "Java", Votes = 0 },
                new PollOption {Id = 3, Title = "C#", Votes = 0 },
                new PollOption {Id = 4, Title = "Ruby", Votes = 0 }
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
    public Poll GetDefaultPoll()
    {
        
        AddDefaultPoll();

        
        return _polls.FirstOrDefault();
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

    
}
