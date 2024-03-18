using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public CategoryController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _ritualbdContext.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> Get(int id)
        {
            Category monument = await _ritualbdContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Categories.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(Category monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Categories.Any(x => x.CategoryId == monument.CategoryId))
            {
                return NotFound();
            }
            _ritualbdContext.Categories.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            Category monument = _ritualbdContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Categories.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
