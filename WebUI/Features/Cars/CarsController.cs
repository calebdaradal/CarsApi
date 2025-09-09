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

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car1 = new Car
            {
                TeamName = "Team A",
                Speed = 100,
                MalfunctionChance = 0.2,
            };

            return Ok(car1);
        }

        // Create Car
        [HttpPost]
        public ActionResult<Car> CreateCar(Car car)
        {
            var newCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MalfunctionChance = car.MalfunctionChance
            };

            return Ok(newCar);
        }

        // Update Car
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(Car car)
        {
            var updateCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MalfunctionChance = car.MalfunctionChance
            };

            return Ok(updateCar);
        }

        // Delete Car
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            return Ok($"Car with id {id} was successfully deleted");
        }
    }
}
