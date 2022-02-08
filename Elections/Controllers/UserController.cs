using AutoMapper;
using Elections.Controllers.Resorces;
using Elections.Models;
using Elections.Persistenc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {

        private readonly ElectionDbContext context;
        private readonly IMapper mapper;

        public UserController(ElectionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = context.Users.ToList().Find(u => u.Id == id);
            if (user == null)
                return NotFound();

            var userResorce = mapper.Map<User, UserResorce>(user);
            return Ok(userResorce);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = context.Users.ToList().Find(u => u.Id == id);
            if (user == null)
                return NotFound();
            context.Users.Remove(user);
            context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult Create([FromBody] UserResorce userResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = mapper.Map<UserResorce, User>(userResorce);
            context.Users.Add(user);
            context.SaveChanges();

            userResorce = mapper.Map<User, UserResorce>(user);
            return Ok(userResorce);
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id, [FromBody] UserResorce userResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToUpdate = context.Users.ToList().Find(u => u.Id == id);
            if (userToUpdate == null)
                return NotFound();
            mapper.Map<UserResorce, User>(userResorce, userToUpdate);
            context.SaveChanges();
            userResorce = mapper.Map<User, UserResorce>(userToUpdate);
            return Ok(userResorce);
        }
    }
}
