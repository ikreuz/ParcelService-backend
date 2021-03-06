using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParcelService.Application.DTO;
using ParcelService.Application.Interface;
using ParcelService.CrossCutting.Common;
using ParcelService.Services.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;
        private readonly List<string> _role = new List<string> { "Master", "Administrator", "Supervisor",
            "Typist", "Courier", "Customer", "Driver" };

        public UsersController(
            IUsersApplication usersApplication,           
            IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;           
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UsersDto usersDto)
        {
            if (usersDto == null) return BadRequest("The login resource mut be allocated.");

            var response = _usersApplication.Authenticate(usersDto.UserName, usersDto.Password);

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDto> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usersDto.Data.UserName)
            }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

    }
}