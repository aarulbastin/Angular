using AngularWebAPIProject.Repository;
using EmployeeViewAngular.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static AngularWebAPIProject.Repository.EmployeeRepository;

namespace EmployeeViewAngular.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IEmployeeRepository _repository;

        public AuthController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost, Route("login")]
       
        public IActionResult Login([FromBody] LoginModel user)
        {
            if(user==null)
            {
                return BadRequest("Invalid client Request");
            }

            if (_repository.checkValidUser(user.Username))
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretKey@345"));
                var signingCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var tokenoptions = new JwtSecurityToken(
                    issuer: "http://localhost:44440/",
                    audience: "http://localhost:44440/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(tokenoptions);
                return Ok(new { Token = tokenstring });
            }

            return Unauthorized();
        }


        [HttpPost, Route("register")]
        public IActionResult Register([FromBody] EmployeeModel userdetails)
        {
            if (userdetails == null)
            {
                return BadRequest("Invalid client Request");
            }

            if (_repository.checkValidUser(userdetails.Name))
            {
                return Ok(ResponseStatus.AlreadyRegistered);
            }
            else
            {
               
                bool register = _repository.RegisterUser(userdetails);
                if (!register)
                {
                    return Ok(ResponseStatus.Fail);
                }
                return Ok(ResponseStatus.Success);
            }
           
        }
    }
}
