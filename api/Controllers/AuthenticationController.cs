using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Entities;
using Microsoft.AspNetCore.Identity;
using api.Configuration;
using Microsoft.Extensions.Options;
using api.Dtos.Requests;
using System.Collections.Generic;
using api.Entities.Dtos.Responses;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Linq;

namespace api.Controllers
{
    /* 
    Authentication Controller
    Controller responsible for the management of the user account information,
    like authentication and registration.
    */
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly TecAirDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(
            TecAirDBContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        /* 
        Register
        POST for registration of users. Saves the information received in the database.
        @param:
            UserRegistrationDto: DTO for user information about registration.
        @return: 
            AuthResult object with the result of the registration process.
        */
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                // We can utilise the model
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Email already in use"
                            },
                        Success = false
                    });
                }

                var newUser = new User()
                {
                    Email = user.Email,
                    UserName = user.FirstName + user.Email.Split('@')[0] + user.Email.Split('.')[0],
                    FirstName = user.FirstName,
                    LastName1 = user.LastName1,
                    LastName2 = user.LastName2,
                    Ssn = int.Parse(user.Ssn),
                    PhoneNumber = user.PhoneNumber,
                    University = user.University,
                    Schoolid = user.SchoolId == null ? null : int.Parse(user.SchoolId)
                };

                if (user.SchoolId != null)
                {
                    var school = new Schoolid()
                    {
                        Number = int.Parse(user.SchoolId),
                        Mile = 0
                    };
                    await _context.Schoolids.AddAsync(school);
                    await _context.SaveChangesAsync();

                    newUser.School = school;
                }
                else
                {
                    newUser.School = null;
                }

                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);
                    _userManager.AddToRoleAsync(newUser, user.Role).Wait();

                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Role = user.Role,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }


        /* 
        Login
        POST for authentication of users.
        @param:
            UserLoginDto: DTO for user information about authentication.
        @return:
            AuthResult object with the result of the authentication process.
        */
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Email does not exist."
                            },
                        Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Incorrect password."
                            },
                        Success = false
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);
                var roles = await _userManager.GetRolesAsync(existingUser);

                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken,
                    Role = roles[0]
                });
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        /* 
        Generate Jwt Token
        Method that generates a token for an authenticated user. This token can be use
        to make further requests to the API.
        @param:
            User: Object that holds the information about the user.
        @return:
            A unique token (string) for the user.
        */
        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }


    }
}