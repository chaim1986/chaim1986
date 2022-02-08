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
    [Route("/api/area")]

    public class AreaController : Controller
    {



        private readonly ElectionDbContext context;
        private readonly IMapper mapper;

        public AreaController(ElectionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateArea([FromBody] AreaResorce RreaResorce)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var area = mapper.Map<AreaResorce, Area>(RreaResorce);
            context.Areas.Add(area);
            context.SaveChanges();
            RreaResorce = mapper.Map<Area, AreaResorce>(area);
            return Ok(RreaResorce);
        }

        [HttpGet]
        public IActionResult GetAreaOfUser(FindArea findArea)
        {
            var areas = context.Elections.Include(a=> a.Areas).ToList().Find(e => e.Id == findArea.electionId).Areas;
            var user = context.Users.ToList().Find(u => u.Id == findArea.userId);
            var Area = areas.Find(a => a.NameOfArea == user.City);
            if (Area == null)
                return NotFound();

          var AreaResorce = mapper.Map<Area, AreaResorce>(Area);

            return Ok(AreaResorce);
        }


        [HttpGet("{id}")]
        public IActionResult GetArea(int id)
        {
            var Area = context.Areas.ToList().Find(a => a.Id == id);
            if (Area == null)
                return NotFound();

            var AreaResorce = mapper.Map<Area, AreaResorce>(Area);

            return Ok(AreaResorce);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Area = context.Areas.ToList().Find(a => a.Id == id);
            if (Area == null)
                return NotFound();
            context.Areas.Remove(Area);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id, [FromBody] AreaResorce areaResorce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AreaToUpdate = context.Areas.ToList().Find(a => a.Id == id);
            if (AreaToUpdate == null)
                return NotFound();
            mapper.Map<AreaResorce, Area>(areaResorce, AreaToUpdate);
            context.SaveChanges();
            mapper.Map<Area, AreaResorce>(AreaToUpdate, areaResorce);

            return Ok(areaResorce);
        }


    }
}

