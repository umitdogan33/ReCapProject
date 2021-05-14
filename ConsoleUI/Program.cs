using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new EfCarDal());
            foreach (var item in car.GetByColorId(1))
            {
                Console.WriteLine(item.CarName);
            }
            
            
            
        }

        private static void DetailsTest()
        {
            EfCarDal efCarDal = new EfCarDal();
            foreach (var item in efCarDal.GetCarDetails())
            {
                Console.WriteLine(item.CarName + "/" + item.ColorName);
            }
        }
    }
}
