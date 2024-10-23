using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GundamAPI.Queries.GetGundamById;
using GundamAPI.Queries.GetAllGundams;

namespace GundamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GundamController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly GundamContext _gundamContext;

        // GET : api/Gundams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gundam>>> GetGundams()
        {
            var query = new GetAllGundamsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET : api/Gundam/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Gundam>> GetGundamById(int id)
        {
            var query = new GetGundamByIdQuery(id);
            var result = await _mediator.Send(query);
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
