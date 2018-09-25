using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel.Entities;
using NuncaCai.Application.Interfaces;

namespace NuncaCai.Api.REST.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerAppService _service;

        public PlayersController(IPlayerAppService service)
        {
            _service = service;
        }

        // GET: api/Players
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            return _service.GetAll();
        }

        //GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _service.GetByIdSync(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer([FromRoute] Guid id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            await _service.UpdateSync(player);
                       
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PlayerExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        [HttpPut("{id}/add-point")]
        public async Task<IActionResult> AddPointPlayer([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddPointSync(id);

            return NoContent();
        }

        [HttpPost]
        [Route("{id}/backup")]
        public async Task<IActionResult> BackupPlayer([FromBody] List<Player> players)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //await _service.AddSync(player);

            return Ok();
        }

        [HttpGet]
        [Route("restore-backup")]
        public async Task<IActionResult> RestoreBackupMatch()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //await _service.AddSync(player);

            return Ok();
        }

        //POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddSync(player);

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }        
    }
}