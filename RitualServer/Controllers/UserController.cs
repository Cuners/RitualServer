using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;
using System.Text.Json.Serialization;
using System.Text.Json;

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
           // var abc= await _ritualbdContext.Users.Include(u => u.Roles).ToListAsync();
           var users=await _ritualbdContext.Users.Include(u=>u.Roles).ToListAsync();
            return Ok(users);
            
        }

        [HttpGet]
        [Route("/getUserWithRole")]
        public async Task<ActionResult<IEnumerable<UserWithRole>>> GetUsersWithRoles()
        {
            var usersWithRoles = await _ritualbdContext.Users
                .Join(_ritualbdContext.Roles,
                    u => u.RoleId,
                    c => c.RolesId,
                    (u, c) => new
                    {
                        UserId = u.UserId,
                        Login = u.Login,
                        Password=u.Password,
                        Name=u.FirstName+ " "+u.LastName,
                        Email=u.Email,
                        Phone=u.Phone,
                        Addres=u.Adress,
                        Role=c.Role1,
                        Image=u.Image
                    })
                .ToListAsync();
            
            return Ok(usersWithRoles);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            //User bluda = await _ritualbdContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            User user=await _ritualbdContext.Users.FirstOrDefaultAsync(x=>x.UserId==id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
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
            _ritualbdContext.Users.Update(user);
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
