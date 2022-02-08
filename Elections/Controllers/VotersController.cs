using AutoMapper;
using Elections.Controllers.Resorces;
using Elections.Models;
using Elections.Persistenc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers
{
    [Route("/api/voters")]

    public class VotersController : Controller
    {

        private readonly ElectionDbContext context;
        private readonly IMapper mapper;

        public VotersController(ElectionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost("{id}")]
        public ActionResult CreateListOfVoters(int id, [FromBody] List<VoterResorce> voterResorces )
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var voters = mapper.Map<List<VoterResorce>, List<Voter>>(voterResorces);

            var election = context.Elections.Include(v=>v.Voters).ToList().Find(e => e.Id == id);
            foreach (var item in voters)
            {
                election.Voters.Add(item);

            }
            context.SaveChanges();

            voterResorces = mapper.Map<List<Voter>, List<VoterResorce>>(voters);


            return Ok(voterResorces);
        }

        [HttpGet("{id}")]
        public IActionResult ListOfVoters(int id)
        {
            List<Voter> voters = context.Elections.Include(v => v.Voters).ToList().Find(e => e.Id == id).Voters;
            if (voters == null)
                return NotFound();
          var  voterResorces = mapper.Map<List<Voter>, List<VoterResorce>>(voters);
            return Ok(voterResorces);
        }




        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var Election = context.Elections.ToList().Find(e => e.Id == id);
        //    if (Election == null)
        //        return NotFound();
        //    context.Elections.Remove(Election);
        //    context.SaveChanges();
        //    return Ok();
        //}

        [HttpPut("[action]/{id}")]

        public ActionResult SetVote(int id, [FromBody] VoterResorce voterResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var VoterToUpdate = context.Voters.ToList().Find(v => v.Id == id);
            if (VoterToUpdate == null)
                return NotFound();
            VoterToUpdate.AlreadyVoted = voterResorce.AlreadyVoted;
            VoterToUpdate.OptionToVoteIdNumber = voterResorce.OptionToVoteIdNumber;
            context.SaveChanges();

            voterResorce = mapper.Map<Voter, VoterResorce>(VoterToUpdate);

            return Ok(voterResorce);
        }


    }
}
