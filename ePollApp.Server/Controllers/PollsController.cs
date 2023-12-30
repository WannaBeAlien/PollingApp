using ePollApp.Server.Models;
using ePollApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ePollApp.Server.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PollsController : ControllerBase
    {
        private readonly IPollService _pollService; 

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

        [HttpGet("default")]
        public ActionResult<Poll> GetDefaultPoll()
        {
            var defaultPoll = new Poll
            {
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

            if (defaultPoll == null)
            {
                return NotFound();
            }

            return Ok(defaultPoll);
        }
    }


}
