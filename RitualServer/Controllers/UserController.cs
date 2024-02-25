using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;
namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public UserController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }
        [HttpGet]
        [Route("/getArticle")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _ritualbdContext.Users.ToListAsync();
        }

        [HttpGet]
        [Route("/getUserWithRole")]
        public async Task<ActionResult<IEnumerable<UserWithRole>>> GetUsersWithRoles()
        {
            var usersWithRoles = await _ritualbdContext.Users
         .Include(user => user.UserNavigation)
         .Select(user => new UserWithRole
         {
             UserId = user.UserId,
             Login = user.Login,
             Password = user.Password,
             Name = user.FirstName+" "+user.LastName,
             
             Email = user.Email,
             Phone = user.Phone,
             Address = user.Adress,
             Image=user.Image,
             Role = user.UserNavigation.Role1 
         })
         .ToListAsync();

            return Ok(usersWithRoles);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User bluda = await _ritualbdContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (bluda == null)
                return NotFound();
            return new ObjectResult(bluda);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Users.Add(user);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Users.Any(x => x.UserId == user.UserId))
            {
                return NotFound();
            }
            _ritualbdContext.Update(user);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = _ritualbdContext.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            _ritualbdContext.Users.Remove(user);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(user);
        }


    }
}
