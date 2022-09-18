using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repo
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCarByID(int id);
        void InsertCar(Car car);
        void DeleteCar(int id);
        void UpdateCar(Car car);
    }
}
