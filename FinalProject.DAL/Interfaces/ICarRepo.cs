using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Interfaces
{
    public interface ICarRepo
    {
        Task Create(Car car);
        Task<Car> Update(Car car);
        Task Delete(Guid id);
        Task<List<Car>> GetAll();
        Task<Car> GetById(Guid id);

    }
}
