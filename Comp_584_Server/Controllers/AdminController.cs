using Comp_584_Server.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WorldModel;

namespace Comp_584_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldModelUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            WorldModelUser? worlduser = await userManager.FindByNameAsync(loginRequest.Username);

            if (worlduser == null)
            {
                return Unauthorized("Invalid Username");
            }
            bool loginStatus = await userManager.CheckPasswordAsync(worlduser, loginRequest.Password);
            if (!loginStatus)
            {
                return Unauthorized("Invalid Password");
            }
            JwtSecurityToken jwtToken = await jwtHandler.GenerateTokenAsync(worlduser);
            string stringToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Login successful.",
                Token = stringToken
            });
        }
    }
}
