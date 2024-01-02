using ePollApp.Server.Models;

namespace ePollApp.Server.Services
{
    
    public interface IPollService
    {
        IEnumerable<Poll> GetPolls();
        Poll GetPollById(int id);
        Poll AddPoll(Poll poll);
        Poll Vote(int pollId, int optionId);
        Poll GetDefaultPoll();

        
    }

}