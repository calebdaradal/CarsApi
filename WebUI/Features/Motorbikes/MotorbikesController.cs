using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Features.Motorbikes
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public MotorbikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorBikes()
        {
            var motorbikes = _context.Motorbikes.ToList();

            return Ok(motorbikes);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Motorbike> GetMotorbike(int id)
        {

            var motorbike = _context.Motorbikes.FirstOrDefault(x => x.Id == id);

            if(motorbike == null)
            {
                return NotFound($"Motorbike with id: {id} is not found");
            }
            return Ok(motorbike);
        }

        //Create Motorbike
        [HttpPost]
        public ActionResult<Motorbike> CreateMotorbike(Motorbike motorbike)
        {

            _context.Motorbikes.Add(motorbike);
            _context.SaveChanges();

            //var newMotorbike = new Motorbike
            //{
            //    Id = motorbike.Id,
            //    TeamName = motorbike.TeamName,
            //    Speed = motorbike.Speed,
            //    MalfunctionChance = motorbike.MalfunctionChance,
            //};

            return Ok(motorbike);
        }
        //Update Motorbike
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Motorbike> updateMotorbike(Motorbike motorbike)
        {
            var dbMotorbike = _context.Motorbikes.FirstOrDefault(x => x.Id == motorbike.Id);

            if (dbMotorbike == null)
            {
                return NotFound($"Motorbike with id: {motorbike.Id} is not found");
            }

            dbMotorbike.TeamName = motorbike.TeamName;
            dbMotorbike.Speed = motorbike.Speed;
            dbMotorbike.MalfunctionChance = motorbike.MalfunctionChance;
            _context.SaveChanges();

            return Ok(dbMotorbike);

        }

        //Delete Motorbike
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Motorbike> deleteMotorbike(int id)
        {
            var dbMotorbike = _context.Motorbikes.FirstOrDefault(x => x.Id == id);

            if (dbMotorbike == null)
            {
                return NotFound($"Motorbike with id: {id} is not found");
            }
            _context.Remove(dbMotorbike);
            _context.SaveChanges();

            return Ok($"Motorbike with id {id} was deleted successfully");
        }
    }
}
