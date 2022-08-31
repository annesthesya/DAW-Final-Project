using FinalProject.BLL.Interfaces;
using FinalProject.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterModel model)
        {

            var result = await _authManager.Register(model);

            if (result) return Ok("Registration Successful");
            else return BadRequest("Registration Failed");
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult> LogIn(LoginModel model)
        {

            var result = await _authManager.Login(model);

            return Ok(result);
        }

        [HttpPost("Refresh")]
        public async Task<ActionResult> Refresh(RefreshModel model)
        {

            var result = await _authManager.Refresh(model);

            return Ok(result);
        }

    }
}
