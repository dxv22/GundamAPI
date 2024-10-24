using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GundamAPI.Queries.GetGundamById;
using GundamAPI.Queries.GetAllGundams;
using GundamAPI.Commands.PostGundamCommand;
using GundamAPI.Commands.UpdateGundamCommand;

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

        //public GundamController(GundamContext gundamContext)
        //{
        //    _gundamContext = gundamContext;
        //}

        // GET : api/Gundams
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Gundam>>> GetGundams()
        //{
        //    if (_gundamContext.Gundams == null)
        //    {
        //        return NotFound();
        //    }

        //    return await _gundamContext.Gundams.ToListAsync();
        //}

        //// GET : api/Gundams/1
        //[HttpGet("{Id}")]
        //[IgnoreAntiforgeryToken]
        //public async Task<ActionResult<GundamDto>> GetGundam(int id)
        //{
        //    if (_gundamContext.Gundams is null)
        //    {
        //        return NotFound();
        //    }

        //    var gundam = await _gundamContext.Gundams.FirstOrDefaultAsync(g => g.Id == id);
        //    if (gundam is null)
        //    {
        //        return NotFound();
        //    }
        //    return gundam;
        //}

        //// POST : api/Gundams
        //[HttpPost]
        //public async Task<ActionResult<GundamDto>> PostGundam(GundamDto gundam)
        //{
        //    _gundamContext.Gundams.Add(gundam);
        //    await _gundamContext.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetGundam), new { id = gundam.Id }, gundam);
        //}

        //// PUT : api/Gundams/1
        //[HttpPut]
        //public async Task<ActionResult<GundamDto>> PutGundam(int id, GundamDto gundam)
        //{
        //    if (id != gundam.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _gundamContext.Entry(gundam).State = EntityState.Modified;

        //    try
        //    {
        //        await _gundamContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GundamExists(id)) { return NotFound(); }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //private bool GundamExists(int id)
        //{
        //    return (_gundamContext.Gundams?.Any(g => g.Id == id)).GetValueOrDefault();
        //}

        //// DELETE : api/Gundams/2
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<GundamDto>> DeleteGundam(int id)
        //{
        //    if (_gundamContext.Gundams is null)
        //    {
        //        return NotFound();
        //    }

        //    var gundam = await _gundamContext.Gundams.FindAsync(id);

        //    if (gundam is null)
        //    {
        //        return NotFound();
        //    }

        //    _gundamContext.Gundams.Remove(gundam);
        //    await _gundamContext.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
