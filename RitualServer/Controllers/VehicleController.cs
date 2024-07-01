using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public VehicleController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getVehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            return await _ritualbdContext.Vehicles.AsNoTracking().AsQueryable().Include(x => x.Model).Include(x => x.Brand).Include(x => x.Services).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get(int id)
        {
            Vehicle Vehicle = await _ritualbdContext.Vehicles.Include(x => x.Model).Include(x => x.Brand).Include(x => x.Services).FirstOrDefaultAsync(x => x.VehicleId == id);
            if (Vehicle == null)
                return NotFound();
            return new ObjectResult(Vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post(Vehicle Vehicle)
        {
            if (Vehicle == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Vehicles.Add(Vehicle);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(Vehicle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> Put(Vehicle Vehicle)
        {
            if (Vehicle == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Vehicles.Any(x => x.VehicleId == Vehicle.VehicleId))
            {
                return NotFound();
            }
            _ritualbdContext.Vehicles.Update(Vehicle);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(Vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> Delete(int id)
        {
            Vehicle Vehicle = _ritualbdContext.Vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            _ritualbdContext.Vehicles.Remove(Vehicle);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(Vehicle);
        }
    }
}
