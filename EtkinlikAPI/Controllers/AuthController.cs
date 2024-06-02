using EtkinlikAPI.Models;
using EtkinlikAPI.Models.DTO;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AkademiEventContext _db;
        public AuthController(AkademiEventContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post(LoginRequestDto model)
        {
            var user = _db.AdminUsers.FirstOrDefault(x => x.EMail == model.EMail && x.Password == model.Password);

            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }
            else
            {
                // kullanici email ve sifresi dogruysa token olustur
                var token = EtkinlikTokenHandler.CreateToken(user.EMail);
                return Ok(token);
            }

        }
    }
}
