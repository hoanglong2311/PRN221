using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowCarManagement : Window
    {
        ICarRepository carRepository;
        public WindowCarManagement(ICarRepository repository)
        {
            InitializeComponent();
            carRepository = repository;
        }

        //GetCarObject
        public Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = Decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

            return car;
        }

        public void LoadCarList()
        {
            lvCars.ItemsSource = carRepository.GetCars();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.InsertCar(car);
                LoadCarList();
                MessageBox.Show("Car Inserted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Car car = GetCarObject();
            carRepository.DeleteCar(car.CarId);
            LoadCarList();
            MessageBox.Show("Car Deleted Successfully");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Car car = GetCarObject();
            carRepository.UpdateCar(car);
            LoadCarList();
            MessageBox.Show("Car Updated Successfully");
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
