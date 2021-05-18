using Core.Utilities.Results;
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
        IDataResult<List<Car>> GetByColorId(int colorıd);
        IResult Add(Car car);
        IDataResult<List<CarDetailsDto>> GetAllDetails();

    }
}
