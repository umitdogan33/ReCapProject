using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Business.Constans;
using Core.Utilities.Interceptors;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("product.add,admin")]
        public IResult Add(Car car)
        {
            IResult Result = BusinessRules.Run(SameCarName(car.CarName));
            if (Result!=null)
            {
                return Result;
            }
            _cardal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult("silme başarılı");
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
            return new ErrorDataResult<Car>(_cardal.Get(p=> p.CarId==Id));
        }

        private IResult SameCarName(string CarName)
        {
           var result =  _cardal.GetAll(p=> p.CarName==CarName).Any();
            if (result)
            {
                return new ErrorResult(Messages.SameCarName);
            }
            return new SuccessResult(Messages.Added);
        }
    }
}
