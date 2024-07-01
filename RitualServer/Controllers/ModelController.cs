using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ModelController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getModels")]
        public async Task<ActionResult<IEnumerable<RitualServer.Model.Model>>> Get()
        {
            return await _ritualbdContext.Models.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RitualServer.Model.Model>>> Get(int id)
        {
            RitualServer.Model.Model monument = await _ritualbdContext.Models.FirstOrDefaultAsync(x => x.ModelId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<RitualServer.Model.Model>> Post(RitualServer.Model.Model monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Models.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RitualServer.Model.Model>> Put(RitualServer.Model.Model monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Models.Any(x => x.ModelId == monument.ModelId))
            {
                return NotFound();
            }
            _ritualbdContext.Models.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RitualServer.Model.Model>> Delete(int id)
        {
            RitualServer.Model.Model monument = _ritualbdContext.Models.FirstOrDefault(x => x.ModelId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Models.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
