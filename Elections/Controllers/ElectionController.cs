using AutoMapper;
using Elections.Controllers.Resorces;
using Elections.Models;
using Elections.Persistenc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Elections.Controllers
{
    
    [Route("/api/elections")]
    //[Authorize]

    public class ElectionController : Controller
    {
        private readonly ElectionDbContext context;
        private readonly IMapper mapper;

        public ElectionController(ElectionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateElection([FromBody]ElectionResorce electionResorce)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var election = mapper.Map<ElectionResorce, Election>(electionResorce);
            context.Elections.Add(election);
            context.SaveChanges();

            electionResorce = mapper.Map<Election, ElectionResorce>(election);

            return Ok(electionResorce);
        }

        [HttpGet("{id}")]
        public IActionResult GetElection(int id)
        {
            var Election = context.Elections.Include(o=> o.optionToVotes).Include(a=> a.Areas).Include(v=> v.Voters).ToList().Find(e => e.Id == id);
            if (Election == null)
                return NotFound();
          var  electionResorce = mapper.Map<Election, ElectionResorce>(Election);

            return Ok(electionResorce);
        } 
        
        //[HttpGet("{id}")]
        //public IActionResult GetElectionsOfTheUser(int id)
        //{
        //    var Elections = context.Elections.ToList().FindAll(e => e.u == id);
        //    if (Election == null)
        //        return NotFound();
        //    return Ok(Election);
        //}

        [HttpGet]
        public IActionResult GetElections()
        {
            var elections = context.Elections.ToList();
            var electionsResorce = mapper.Map<List<Election>,List<ElectionResorce>>(elections);
            return Ok(electionsResorce);
        }
        

        [HttpGet("[action]/{id}")]
        public IActionResult GetElectionsOfUser(int id)
        {
            List<VoterResorce> voterResorce = new List<VoterResorce>();
            var user = context.Users.ToList().Find(u => u.Id == id);
            if (user!=null)
            {
                List<Voter> voters = context.Voters.Include(e => e.Election).ToList().FindAll(v => v.PhoneNumber == user.PhoneNumber);
                voterResorce = mapper.Map<List<Voter>, List<VoterResorce>>(voters);
            }
            
            //List<Election> elections = new List<Election>();
            //foreach (var item in voters)
            //{
            //    elections.Add(item.Election);
            //}
            //var electionsResorce = mapper.Map<List<Election>,List<ElectionResorce>>(elections);
            return Ok(voterResorce);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Election = context.Elections.ToList().Find(e => e.Id == id);
            if (Election == null)
                return NotFound();
            context.Elections.Remove(Election);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id, [FromBody] ElectionResorce electionResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ElectionToUpdate = context.Elections.ToList().Find(u => u.Id == id);
            if (ElectionToUpdate == null)
                return NotFound();
            mapper.Map<ElectionResorce, Election>(electionResorce, ElectionToUpdate);
            context.SaveChanges();

            electionResorce = mapper.Map<Election, ElectionResorce>(ElectionToUpdate);

            return Ok(electionResorce);
        }


    }
}
