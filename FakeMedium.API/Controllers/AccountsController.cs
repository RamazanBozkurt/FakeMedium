using AutoMapper;
using FakeMedium.DATA.Context;
using FakeMedium.MODELS.DTO.Request.User;
using FakeMedium.SERVICES.Abstract;
using FakeMedium.SERVICES.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FakeMedium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountsController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly FakeMediumDbContext _context;
        private readonly IUserService _userService;
        public AccountsController(IConfiguration configuration, FakeMediumDbContext context, IUserService userService)
        {
            Configuration = configuration;
            _context = context;
            _userService = userService; 
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]UserLoginRequest userLogin)
        {
            var user = _userService.UserValidate(userLogin.Username, userLogin.Password);

            if (user == null)
            {
                return BadRequest("Kullanıcı adı veya parola hatalı.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var bearer = Configuration.GetSection("Bearer");
            var issuer = bearer["Issuer"];
            var audience = bearer["Audience"];
            var key = bearer["SecurityKey"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             claims: claims,
                                             notBefore: DateTime.Now,
                                             expires: DateTime.Now.AddMinutes(20),   
                                             signingCredentials: credential);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var response = _userService.GetAllUsers();

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var response = _userService.GetUserById(id);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("Register/")]
        [AllowAnonymous]
        public IActionResult AddNewUser([FromBody]AddNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastUserId = _userService.AddNewUser(request);
                return CreatedAtAction(nameof(GetUserById), new { id = lastUserId }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody]UpdateUserRequest request)
        {
            var isExist = _userService.IsExist(request.Id);

            if (isExist)
            {
                if (ModelState.IsValid)
                {
                    var updatedUser = _userService.UpdateUser(request);
                    return Ok(updatedUser);
                }

                return BadRequest(ModelState);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute]int id)
        {
            var isExist = _userService.IsExist(id);

            if (isExist)
            {
                var response = _userService.DeleteUser(id);
                return Ok($"{response} isimli kullanıcı veritabanından başarıyla silinmiştir.");
            }

            return NotFound();
        }

        [HttpGet("Search/")]
        public IActionResult Search([FromRoute]string query)
        {
            var response = _userService.SearchUser(query);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
