using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public BrandController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> Get()
        {
            return await _ritualbdContext.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Brand>>> Get(int id)
        {
            Brand monument = await _ritualbdContext.Brands.FirstOrDefaultAsync(x => x.BrandId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> Post(Brand monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Brands.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> Put(Brand monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Brands.Any(x => x.BrandId == monument.BrandId))
            {
                return NotFound();
            }
            _ritualbdContext.Brands.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> Delete(int id)
        {
            Brand monument = _ritualbdContext.Brands.FirstOrDefault(x => x.BrandId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Brands.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
