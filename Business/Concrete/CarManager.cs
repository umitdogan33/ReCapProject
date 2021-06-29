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
using Core.Aspects.Autofac.Caching;

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
        // [SecuredOperation("product.add,admin")]
        public IResult Add(Car car)
        {
            IResult Result = BusinessRules.Run(SameCarName(car.CarName));
            if (Result != null)
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

        public IDataResult<List<CarDetailsDto>> GetByBrandId(int Brandid)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_cardal.GetCarDetails(P => P.BrandId == Brandid));
        }

        public IDataResult<List<CarDetailsDto>> GetByBrandIdAndColorId(int brandId, int colorid)
        {
            if (brandId != 0)
            {
                return new SuccessDataResult<List<CarDetailsDto>>(_cardal.GetCarDetails(P => P.BrandId == brandId && P.ColorId == colorid));
            }

            if (colorid != 0)
            {
                return new SuccessDataResult<List<CarDetailsDto>>(_cardal.GetCarDetails(P => P.BrandId == brandId && P.ColorId == colorid));
            }



            return new SuccessDataResult<List<CarDetailsDto>>(_cardal.GetCarDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetByColorId(int colorid)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_cardal.GetCarDetails(p => p.ColorId == colorid));
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_cardal.Get(p => p.CarId == Id));
        }


        public IDataResult<Car> GetCarsByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_cardal.Get(p => p.CarId == carId));
        }

        public IDataResult<CarDetailsDto> GetDetailsByCarId(int Carid)
        {
            return new SuccessDataResult<CarDetailsDto>(_cardal.GetCarDetail(p=> p.CarId== Carid));
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult();
          
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
