using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public UserOrderController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getUserOrders")]
        public async Task<ActionResult<IEnumerable<UsersOrder>>> Get()
        {
            return await _ritualbdContext.UsersOrders.Include(x => x.Users).Include(x => x.Orders).Include(x => x.Orders.Status).Include(x => x.Orders.Shipments).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UsersOrder>>> Get(int id)
        {
            UsersOrder monument = await _ritualbdContext.UsersOrders.FirstOrDefaultAsync(x => x.UsersOrderID == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<UsersOrder>> Post(UsersOrder monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.UsersOrders.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsersOrder>> Put(UsersOrder monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.UsersOrders.Any(x => x.UsersOrderID == monument.UsersOrderID))
            {
                return NotFound();
            }
            _ritualbdContext.UsersOrders.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersOrder>> Delete(int id)
        {
            UsersOrder monument = _ritualbdContext.UsersOrders.FirstOrDefault(x => x.UsersOrderID == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.UsersOrders.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
