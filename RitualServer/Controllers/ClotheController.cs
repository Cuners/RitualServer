using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClotheController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ClotheController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getClothes")]
        public async Task<ActionResult<IEnumerable<Clothe>>> Get()
        {
            return await _ritualbdContext.Clothes.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Clothe>>> Get(int id)
        {
            Clothe monument = await _ritualbdContext.Clothes.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).FirstOrDefaultAsync(x => x.ClothId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Coffin>> Post(Clothe monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Clothes.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Clothe>> Put(Clothe monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Clothes.Any(x => x.ClothId == monument.ClothId))
            {
                return NotFound();
            }
            _ritualbdContext.Clothes.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Clothe>> Delete(int id)
        {
            Clothe monument = _ritualbdContext.Clothes.FirstOrDefault(x => x.ClothId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Clothes.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
