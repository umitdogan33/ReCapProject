using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        public IResult Add(Car car)
        {
            _cardal.Add(car);
            return new SuccessResult("ekleme başarılı");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll());
        }

        public IDataResult<List<CarDetailsDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_cardal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetByColorId(int colorıd)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p=> p.ColorId==colorıd));
        }

        public IDataResult<Car> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
