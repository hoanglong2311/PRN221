using AutomobileLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    internal class CarRepository : ICarRepository
    {
        void ICarRepository.DeleteCar(int id) => CarManagement.Instance.deleteCar(id);

        Car ICarRepository.GetCarByID(int id) => CarManagement.Instance.getCarById(id);

        IEnumerable<Car> ICarRepository.GetCars() => CarManagement.Instance.getCarList();
        
        void ICarRepository.InsertCar(Car car) => CarManagement.Instance.addCar(car);

        void ICarRepository.UpdateCar(Car car) => CarManagement.Instance.updateCar(car);
    }
}
