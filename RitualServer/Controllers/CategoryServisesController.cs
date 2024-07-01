using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryServisesController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public CategoryServisesController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getCategoriesServices")]
        public async Task<ActionResult<IEnumerable<CategoiresService>>> Get()
        {
            return await _ritualbdContext.CategoiresServices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CategoiresService>>> Get(int id)
        {
            CategoiresService monument = await _ritualbdContext.CategoiresServices.FirstOrDefaultAsync(x => x.CategoriesServicesId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<CategoiresService>> Post(CategoiresService monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.CategoiresServices.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoiresService>> Put(CategoiresService monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.CategoiresServices.Any(x => x.CategoriesServicesId == monument.CategoriesServicesId))
            {
                return NotFound();
            }
            _ritualbdContext.CategoiresServices.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoiresService>> Delete(int id)
        {
            CategoiresService monument = _ritualbdContext.CategoiresServices.FirstOrDefault(x => x.CategoriesServicesId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.CategoiresServices.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
