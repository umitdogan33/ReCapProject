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
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailsDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetByColorId(int colorıd)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
