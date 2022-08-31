using FinalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Repositories
{
    public class CarRepo : ICarRepo
    {
        private readonly AppDBContext _context;

        public CarRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task Create(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var car = _context.Cars.Find(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> Update(Car newCar)
        {
            var car = _context
                .Cars
                .Find(newCar.Id);

            if (newCar.LicensePlateNumber != null)
                car.LicensePlateNumber = newCar.LicensePlateNumber;
            if (newCar.LicensePlateNumber != null) 
                car.Manufacturer = newCar.Manufacturer;
            if (newCar.Model != null)
                car.Model = newCar.Model;
            if (newCar.Colour != null)
                car.Colour = newCar.Colour;
           
        await _context.SaveChangesAsync();

            return car;
        }

        public async Task<List<Car>> GetAll()
        {
            var cars = await _context
               .Cars
               .ToListAsync();

            return cars;
        }

        public Task<Car> GetById(Guid id)
        {
            var car = _context
                .Cars
                .Find(id);

            return Task.FromResult(car);
        }
    }
}
