using FinalProject.BLL.Interfaces;
using FinalProject.DAL;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ICarRepo _carRepository;

        public CarController(ICarRepo carRepository, AppDBContext context)
        {
            _carRepository = carRepository;
            _context = context;
        }

        [HttpPost("CreateCar")]
        [Authorize("Admin")]
        public async Task<ActionResult> CreateCar([FromBody] Car car)
        {
            await _carRepository.Create(car);
            return Ok("Car Added Successfully");
        }

        [HttpGet("ReadCar/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> ReadCar([FromRoute] Guid id)
        {
            var car = _carRepository.GetById(id);
            if (car == null)
                return NotFound("Car with that ID does not exist.");
            return Ok(car);
        }

        [HttpGet("GetCarsShow")]
        [Authorize("Admin")]
        public async Task<ActionResult> GetCars()
        {
            var cars = await _context
                .Cars
                .ToListAsync();

            var strings = new List<string>();

            foreach (var car in cars)
            {
                strings.Add($"Name:{car.Manufacturer} {car.Model}, License Plate: {car.LicensePlateNumber}" +
                    $",ID:{car.Id}");
            }

            return Ok(strings);
        }

        [HttpPut("UpdateCar")]
        [Authorize("Admin")]
        public async Task<ActionResult> UpdateCar([FromBody] Car car)
        {
            var updatedCar = _carRepository.Update(car);
            if (updatedCar == null)
                return NotFound("Car with that ID does not exist. Update failed.");
            return Ok("Update Successful.");
        }

        [HttpGet("DeleteCar/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> DeleteCar([FromRoute] Guid id)
        {
            await _carRepository.Delete(id);
            return Ok("Car Deleted Successfully");
        }

    }
}
