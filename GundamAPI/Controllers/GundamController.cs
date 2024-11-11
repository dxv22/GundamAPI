using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GundamAPI.Queries.GetGundamById;
using GundamAPI.Queries.GetAllGundams;
using GundamAPI.Commands.PostGundamCommand;
using GundamAPI.Commands.UpdateGundamCommand;
using GundamAPI.Commands.DeleteGundamCommand;

namespace GundamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GundamController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Gets all Gundam
        /// </summary>
        /// <returns>A collection of Gundam</returns>
        // GET : api/Gundam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gundam>>> GetGundams()
        {
            var query = new GetAllGundamsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Gets a Gundam by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gundam</returns>
        // GET : api/Gundam/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Gundam>> GetGundamById(int id)
        {
            var query = new GetGundamByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Adds a new Gundam
        /// </summary>
        /// <param name="gundam"></param>
        /// <returns>Gundam status response</returns>
        // POST : api/Gundam
        [HttpPost]
        public async Task<ActionResult<Gundam>> PostGundam(GundamDto gundam)
        {
            var command = new PostGundamCommand(gundam);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGundamById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates existing gundam
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gundam"></param>
        /// <returns>Gundam status respons if successful, throws exception if false</returns>
        // PUT : api/Gundam/1
        [HttpPatch]
        public async Task<ActionResult<bool>> UpdateGundam(int id, GundamDto gundam)
        {
            var command = new UpdateGundamCommand(id, gundam);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGundam(int id)
        {
            var command = new DeleteGundamCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
