using ePollApp.Server.Models;
using ePollApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePollApp.Server.Controllers
{
    // Controllers/VotesController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IPollService _pollService; 

        public VotesController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpPost("{pollId}/vote/{optionId}")]
        public ActionResult<Poll> Vote(int pollId, int optionId)
        {
            var poll = _pollService.Vote(pollId, optionId);
            if (poll == null)
            {
                return NotFound();
            }

            return Ok(poll);
        }
    }

}
