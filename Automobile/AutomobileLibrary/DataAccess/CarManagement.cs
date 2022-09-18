using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    internal class CarManagement
    {

        //using sigleton pattern
        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();
        private CarManagement() { }
        public static CarManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }

        //using list to store data
        public IEnumerable<Car> getCarList()
        {
            List<Car> cars;
            try
            {
                var myStockDB = new MyStockContext();
                cars = myStockDB.Cars.ToList();
            }
            catch (Exception e)
            {            
                throw new Exception(e.Message);
            }
            return cars;
        }

        public Car getCarById(int id)
        {
            Car car;
            try
            {
                var myStockDB = new MyStockContext();
                car = myStockDB.Cars.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return car;
        }

        public void updateCar(Car car)
        {
            try
            {
                Car c = getCarById(car.CarId);
                if (c != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Entry<Car>(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStockDB.SaveChanges();
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addCar(Car car)
        {
            try
            {
                Car _car = getCarById(car.CarId);
                if(_car == null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();
                } else
                {
                    throw new Exception("The car is alredy exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void deleteCar(int id)
        {
            try
            {
                Car car = getCarById(id);
                if (car != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Remove(car);
                    myStockDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
