using ePollApp.Server.Models;

namespace ePollApp.Server.Services
{
    // Services/IPollService.cs
    public interface IPollService
    {
        IEnumerable<Poll> GetPolls();
        Poll GetPollById(int id);
        Poll AddPoll(Poll poll);
        Poll Vote(int pollId, int optionId);
        // Add other methods as needed
    }

}