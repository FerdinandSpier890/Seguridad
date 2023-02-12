using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguridad2.Data;
using Seguridad2.Interfaces;
using Seguridad2.Models;

namespace Seguridad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public UsersController(DataContext context, ITokenService tokenService)
        {
            //Inyección del Usuario
            _context = context;

            //Inyeccion del Token
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Users()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
