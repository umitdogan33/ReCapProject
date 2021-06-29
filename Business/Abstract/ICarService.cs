using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
      IDataResult<Car>  GetById(int Id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetByColorId(int colorid);
        IDataResult<List<CarDetailsDto>> GetByBrandIdAndColorId(int brandId,int colorid);
        IResult Add(Car car);
        IDataResult<List<CarDetailsDto>> GetAllDetails();
        IResult Delete(Car car);
        IDataResult<List<CarDetailsDto>> GetByBrandId(int Brandid);
        IDataResult<Car> GetCarsByCarId(int carId);
        IDataResult<CarDetailsDto> GetDetailsByCarId(int carId);

        IResult Update(Car car);
    }
}
