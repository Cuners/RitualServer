using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public MaterialController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getMaterials")]
        public async Task<ActionResult<IEnumerable<Material>>> Get()
        {
            return await _ritualbdContext.Materials.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Material>>> Get(int id)
        {
            Material monument = await _ritualbdContext.Materials.FirstOrDefaultAsync(x => x.MaterialId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Material>> Post(Material monument)
        {
            if (monument == null || _ritualbdContext.Materials.Any(x => x.Name == monument.Name))
            {
                return BadRequest();
            }
            _ritualbdContext.Materials.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Material>> Put(Material monument)
        {
            if (monument == null || _ritualbdContext.Materials.Any(x => x.Name == monument.Name))
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Materials.Any(x => x.MaterialId == monument.MaterialId))
            {
                return NotFound();
            }
            _ritualbdContext.Materials.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Material>> Delete(int id)
        {
            Material monument = _ritualbdContext.Materials.FirstOrDefault(x => x.MaterialId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Materials.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
