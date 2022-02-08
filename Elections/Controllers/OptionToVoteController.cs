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
    [Route("/api/option")]

    public class OptionToVoteController : Controller
    {

        private readonly ElectionDbContext context;
        private readonly IMapper mapper;

        public OptionToVoteController(ElectionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateOptionToVote([FromBody] OptionToVoteResorce optionToVoteResorce)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var option = mapper.Map<OptionToVoteResorce, OptionToVote>(optionToVoteResorce);
            context.OptionToVotes.Add(option);
            context.SaveChanges();

            optionToVoteResorce = mapper.Map<OptionToVote, OptionToVoteResorce>(option);

            return Ok(optionToVoteResorce);
        }

        [HttpGet("{id}")]
        public IActionResult GetOption(int id)
        {
            var Option = context.OptionToVotes.ToList().Find(o => o.Id == id);
            if (Option == null)
                return NotFound();

         var   optionToVoteResorce = mapper.Map<OptionToVote, OptionToVoteResorce>(Option);

            return Ok(optionToVoteResorce);
        }
        
        
        [HttpGet("[action]/{id}")]
        public IActionResult GetOptionsOfElection(int id)
        {
            var options = context.Elections.Include(o => o.optionToVotes).ToList().Find(e => e.Id == id).optionToVotes;
            if (options == null)
                return NotFound();

         var   optionsToVoteResorce = mapper.Map<List< OptionToVote>,List< OptionToVoteResorce>>(options);

            return Ok(optionsToVoteResorce);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Option = context.OptionToVotes.ToList().Find(o => o.Id == id);
            if (Option == null)
                return NotFound();
            context.OptionToVotes.Remove(Option);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id, [FromBody] OptionToVoteResorce optionToVoteResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OptionToUpdate = context.OptionToVotes.ToList().Find(o => o.Id == id);
            if (OptionToUpdate == null)
                return NotFound();
            mapper.Map<OptionToVoteResorce, OptionToVote>(optionToVoteResorce, OptionToUpdate);
            context.SaveChanges();

            optionToVoteResorce = mapper.Map<OptionToVote, OptionToVoteResorce>(OptionToUpdate);

            return Ok(optionToVoteResorce);
        }


    }
}