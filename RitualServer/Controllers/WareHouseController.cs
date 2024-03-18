using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public WareHouseController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getWareHouses")]
        public async Task<ActionResult<IEnumerable<WareHouse>>> Get()
        {
            return await _ritualbdContext.WareHouses.AsNoTracking().AsQueryable().Include(x=>x.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<WareHouse>>> Get(int id)
        {
            WareHouse wareHouse = await _ritualbdContext.WareHouses.FirstOrDefaultAsync(x => x.CompositionId == id);
            if (wareHouse == null)
                return NotFound();
            return new ObjectResult(wareHouse);
        }

        [HttpPost]
        public async Task<ActionResult<WareHouse>> Post(WareHouse wareHouse)
        {
            if (wareHouse == null)
            {
                return BadRequest();
            }
            _ritualbdContext.WareHouses.Add(wareHouse);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(wareHouse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WareHouse>> Put(WareHouse wareHouse)
        {
            if (wareHouse == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Roles.Any(x => x.RolesId == wareHouse.CompositionId))
            {
                return NotFound();
            }
            _ritualbdContext.Update(wareHouse);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(wareHouse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            WareHouse wareHouse = _ritualbdContext.WareHouses.FirstOrDefault(x => x.CompositionId == id);
            if (wareHouse == null)
            {
                return NotFound();
            }
            _ritualbdContext.WareHouses.Remove(wareHouse);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(wareHouse);
        }
    }
}
