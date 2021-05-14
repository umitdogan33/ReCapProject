using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        public List<CarDetailsDto> GetAll()
        {
            return _cardal.GetCarDetails();
        }

        public List<Car> GetByColorId(int colorıd)
        {
            return _cardal.GetAll(p => p.ColorId == colorıd);
        }

        public Car GetById(int Id)
        {
            return _cardal.Get(p => p.CarId == Id);
        }
    }
}
