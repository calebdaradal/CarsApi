using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = _context.Cars.ToList(); 

            return Ok(cars);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);

            if(car == null)
            {
                return NotFound($"Car with id: {id} hasn't been found");
            }

            return Ok(car);
        }

        // Create Car
        [HttpPost]
        public ActionResult<Car> CreateCar(Car car)
        {

            _context.Cars.Add(car);
            _context.SaveChanges();



            //var newCar = new Car
            //{
            //    Id = car.Id,
            //    TeamName = car.TeamName,
            //    Speed = car.Speed,
            //    MalfunctionChance = car.MalfunctionChance
            //};

            return Ok(car);
        }

        // Update Car
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(Car car)
        {
            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == car.Id);

            if(dbCar == null)
            {
                return NotFound($"Car with id {car.Id} isn't found");
            }

            dbCar.TeamName = car.TeamName;
            dbCar.Speed = car.Speed;
            dbCar.MalfunctionChance = car.MalfunctionChance;
            _context.SaveChanges();

            return Ok(dbCar);
        }

        // Delete Car
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (dbCar == null)
            {
                return NotFound($"Car with id {id} isn't found");
            }

            _context.Remove(dbCar);
            _context.SaveChanges();

            return Ok($"Car with id: {id} was successfully deleted");
        }
    }
}
