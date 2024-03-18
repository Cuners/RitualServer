using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ProductController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _ritualbdContext.Products.AsNoTracking().AsQueryable().Include(x=>x.Category).Include(x=>x.Clothes).Include(x=>x.Monuments).Include(x=>x.Urns).Include(x=>x.Tapes).Include(x=>x.Coffins).Include(x=>x.Crosses).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> Get(int id)
        {
            Product product = await _ritualbdContext.Products.AsNoTracking().AsQueryable().Include(x => x.Category).Include(x => x.Clothes).Include(x => x.Monuments).Include(x => x.Urns).Include(x => x.Tapes).Include(x => x.Coffins).Include(x => x.Crosses).FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
                return NotFound();
            return new ObjectResult(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Products.Add(product);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Roles.Any(x => x.RolesId == product.ProductId))
            {
                return NotFound();
            }
            _ritualbdContext.Products.Update(product);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            Product product = _ritualbdContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            _ritualbdContext.Products.Remove(product);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(product);
        }
    }
}
