using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public RoleController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getRoles")]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return await _ritualbdContext.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Role>>> Get(int id)
        {
            Role bluda = await _ritualbdContext.Roles.FirstOrDefaultAsync(x => x.RolesId == id);
            if (bluda == null)
                return NotFound();
            return new ObjectResult(bluda);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Post(Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Roles.Add(role);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> Put(Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Roles.Any(x => x.RolesId == role.RolesId))
            {
                return NotFound();
            }
            _ritualbdContext.Roles.Update(role);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            Role role = _ritualbdContext.Roles.FirstOrDefault(x => x.RolesId == id);
            if (role == null)
            {
                return NotFound();
            }
            _ritualbdContext.Roles.Remove(role);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(role);
        }
    }
}
