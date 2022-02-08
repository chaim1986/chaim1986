using Elections.Controllers.Resorces;
using Elections.Persistenc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Elections.Controllers
{
    [Route("/auth")]
    public class AuthController : Controller
    {
        private readonly ElectionDbContext context;
        private IConfiguration _config;

            public AuthController(ElectionDbContext context, IConfiguration config)
            {
                _config = config;
                this.context = context;
            }
            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login([FromBody] UserResorce user)
            {
                var users = context.Users.ToList();
                var userToSend = users.Find(u => u.EmailAdress == user.EmailAdress);
            if (userToSend == null)
                return Unauthorized();

            if (userToSend.Password == user.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@345"));
                var signingCredentails = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44316",
                    //audience: "https://localhost:44316",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: signingCredentails

                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token= tokenString, userId=userToSend.Id, isManager=user.IsManager });
            };
            return Unauthorized();


           


            }


           
        }
    }
