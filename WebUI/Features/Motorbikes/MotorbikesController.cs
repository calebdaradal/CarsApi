using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Features.Motorbikes
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorBikes()
        {
            var motorbikes = new List<Motorbike>();
            var motorbike1 = new Motorbike
            {
                Id = 1,
                TeamName = "Team A",
                Speed = 120,
                MalfunctionChance = 0.5
            };
            var motorbike2 = new Motorbike
            {
                Id = 2,
                TeamName = "Team B",
                Speed = 60,
                MalfunctionChance = 0.1
            };

            motorbikes.Add(motorbike1);
            motorbikes.Add(motorbike2);

            return Ok(motorbikes);
        }

        //Create Motorbike
        [HttpPost]
        public ActionResult<Motorbike> CreateMotorbike(Motorbike motorbike)
        {
            var newMotorbike = new Motorbike
            {
                Id = motorbike.Id,
                TeamName = motorbike.TeamName,
                Speed = motorbike.Speed,
                MalfunctionChance = motorbike.MalfunctionChance,
            };

            return Ok(newMotorbike);
        }
        //Update Motorbike
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Motorbike> updateMotorbike(Motorbike motorbike)
        {
            var motorbikeToUpdate = new Motorbike
            {
                Id = motorbike.Id,
                TeamName = motorbike.TeamName,
                Speed = motorbike.Speed,
                MalfunctionChance = motorbike.MalfunctionChance
            };

            return Ok(motorbikeToUpdate);
        }

        //Delete Motorbike
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Motorbike> deleteMotorbike(int id)
        {
            return Ok($"Motorbike with id {id} was deleted successfully");
        }
    }
}
