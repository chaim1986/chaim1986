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
    [Route("/api/faults")]

    public class FaultController : Controller
    {

        private readonly ElectionDbContext context;
        private readonly IMapper mapper;

        public FaultController(ElectionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpPost]
        public ActionResult CreateFault([FromBody] FaultResorce faultResorce)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fault = mapper.Map<FaultResorce, Fault>(faultResorce);

            context.Faults.Add(fault);
            context.SaveChanges();

            faultResorce = mapper.Map<Fault, FaultResorce>(fault);

            return Ok(fault);
        }

        [HttpGet("{id}")]
        public IActionResult GetFault(int id)
        {
            var Fault = context.Faults.ToList().Find(f => f.Id == id);
            if (Fault == null)
                return NotFound();
          var  faultResorce = mapper.Map<Fault, FaultResorce>(Fault);
            return Ok(faultResorce);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetFaultsOfInspector(int id)
        {
            var user = context.Users.ToList().Find(u => u.Id == id);
            var voters = context.Voters.Include(e=> e.Election).ThenInclude(a=> a.Areas).ThenInclude(f=> f.faults).ThenInclude(r=> r.Replies).ToList().FindAll(v => v.PhoneNumber == user.PhoneNumber && v.IsInspector);
            if (voters == null)
                return NotFound();
            List<Election> elections = new List<Election>();
            foreach (var item in voters)
            {
                elections.Add(item.Election);
            }
            var electionsResorce = mapper.Map<List<Election>, List<ElectionResorce>>(elections);

            List<FaulteToSendResorce> faulteToSendResorces = new List<FaulteToSendResorce>();
            foreach (var Election in electionsResorce)
            {
                foreach (var Area in Election.Areas)
                {
                    if (Area.NameOfArea==user.City)
                    {
                        faulteToSendResorces.Add(new FaulteToSendResorce { area = Area, electionName = Election.NameOfTheElection });
                    }
                    
                }
            }
            return Ok(faulteToSendResorces);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Fault = context.Faults.ToList().Find(f => f.Id == id);
            if (Fault == null)
                return NotFound();
            context.Faults.Remove(Fault);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id, [FromBody] FaultResorce faultResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var FaultToUpdate = context.Faults.ToList().Find(f => f.Id == id);
            if (FaultToUpdate == null)
                return NotFound();
            mapper.Map<FaultResorce, Fault>(faultResorce, FaultToUpdate);
            context.SaveChanges();
            faultResorce = mapper.Map<Fault, FaultResorce>(FaultToUpdate);
            return Ok(faultResorce);
        }


    }
}

