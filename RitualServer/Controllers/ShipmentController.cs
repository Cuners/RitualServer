using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ShipmentController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getShipments")]
        public async Task<ActionResult<IEnumerable<Shipment>>> Get()
        {
            return await _ritualbdContext.Shipments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Shipment>>> Get(int id)
        {
            Shipment monument = await _ritualbdContext.Shipments.FirstOrDefaultAsync(x => x.ShipmentId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Shipment>> Post(Shipment monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Shipments.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Shipment>> Put(Shipment monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Shipments.Any(x => x.ShipmentId == monument.ShipmentId))
            {
                return NotFound();
            }
            _ritualbdContext.Shipments.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipment>> Delete(int id)
        {
            Shipment monument = _ritualbdContext.Shipments.FirstOrDefault(x => x.ShipmentId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Shipments.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
