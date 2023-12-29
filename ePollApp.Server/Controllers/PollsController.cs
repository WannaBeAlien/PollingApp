using ePollApp.Server.Models;
using ePollApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePollApp.Server.Controllers
{
    // Controllers/PollsController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class PollsController : ControllerBase
    {
        private readonly IPollService _pollService; // Replace with your own service or repository

        public PollsController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Poll>> GetPolls()
        {
            var polls = _pollService.GetPolls();
            return Ok(polls);
        }

        [HttpGet("{id}")]
        public ActionResult<Poll> GetPollById(int id)
        {
            var poll = _pollService.GetPollById(id);
            if (poll == null)
            {
                return NotFound();
            }

            return Ok(poll);
        }

        [HttpPost("add")]
        public ActionResult<Poll> AddPoll([FromBody] Poll poll)
        {
            var addedPoll = _pollService.AddPoll(poll);
            return CreatedAtAction(nameof(GetPollById), new { id = addedPoll.Id }, addedPoll);
        }

        // Implement other actions for updating and deleting polls
    }


}
