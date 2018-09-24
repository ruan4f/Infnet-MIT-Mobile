using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel.Entities;
using NuncaCai.Application.Interfaces;
using NuncaCai.Api.REST.Model;

namespace NuncaCai.Api.REST.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchAppService _service;

        public MatchesController(IMatchAppService service)
        {
            _service = service;
        }

        // GET: api/Matches
        [HttpGet]
        public IEnumerable<Match> GetMatches()
        {
            return _service.GetAll();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _service.GetByIdSync(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // POST: api/Matches
        [HttpPost]
        public async Task<IActionResult> PostMatch([FromBody] MatchModel match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddSync(match.Id, match.Player1Id, match.Player2Id, match.WinnerId);
            
            return Ok();
        }        
    }
}