using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = new List<Car>();
            var car1 = new Car
            {
                TeamName = "Team A",
                Speed = 100,
                MalfunctionChance = 0.2,
            };
            var car2 = new Car
            {
                TeamName = "Team B",
                Speed = 90,
                MalfunctionChance = 0.15,
            };
            cars.Add(car1);
            cars.Add(car2);

            return Ok(cars);
        }
    }
}
