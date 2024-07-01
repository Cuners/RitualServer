using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ServiceController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getServices")]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            return await _ritualbdContext.Services.AsNoTracking().AsQueryable().Include(x => x.Category).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Service>>> Get(int id)
        {
            Service Service = await _ritualbdContext.Services.AsNoTracking().AsQueryable().Include(x => x.Category).FirstOrDefaultAsync(x => x.ServicesId == id);
            if (Service == null)
                return NotFound();
            return new ObjectResult(Service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service Service)
        {
            if (Service == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Services.Add(Service);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(Service);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Put(Service Service)
        {
            if (Service == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Services.Any(x => x.ServicesId == Service.ServicesId))
            {
                return NotFound();
            }
            _ritualbdContext.Services.Update(Service);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(Service);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            Service Service = _ritualbdContext.Services.FirstOrDefault(x => x.ServicesId == id);
            if (Service == null)
            {
                return NotFound();
            }
            _ritualbdContext.Services.Remove(Service);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(Service);
        }
    }
}
