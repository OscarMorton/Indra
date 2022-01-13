using Indra.Application.services;
using Indra.Application.services.Interfaces;
using Indra.Domain.Entities;
using Indra.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.JwtHelpers;

namespace Idra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly JwtSettings jwtSettings;

        public UserController(IUserService userService, JwtSettings jwtSettings)
        {
            _userService = userService;
            this.jwtSettings = jwtSettings;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(UserLoginDto userLogins)
        {
            try
            {
                IEnumerable<UserEntity> userDto = await _userService.GetAll();
                var Token = new UserTokens();

                var Valid = userDto.Any(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = userDto.FirstOrDefault(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                    }, jwtSettings);
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}