using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlozheniaMessController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public VlozheniaMessController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getVlozheniaMesss")]
        public async Task<ActionResult<IEnumerable<VlozheniaMess>>> Get()
        {
            return await _ritualbdContext.VlozheniaMesses.Include(x=>x.Message).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VlozheniaMess>>> Get(int id)
        {
            VlozheniaMess monument = await _ritualbdContext.VlozheniaMesses.FirstOrDefaultAsync(x => x.VlozheniaMessId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<VlozheniaMess>> Post(VlozheniaMess monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.VlozheniaMesses.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VlozheniaMess>> Put(VlozheniaMess monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.VlozheniaMesses.Any(x => x.VlozheniaMessId == monument.VlozheniaMessId))
            {
                return NotFound();
            }
            _ritualbdContext.VlozheniaMesses.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VlozheniaMess>> Delete(int id)
        {
            VlozheniaMess monument = _ritualbdContext.VlozheniaMesses.FirstOrDefault(x => x.VlozheniaMessId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.VlozheniaMesses.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
