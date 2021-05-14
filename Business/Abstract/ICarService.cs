using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
      Car  GetById(int Id);
        List<CarDetailsDto> GetAll();
        List<Car> GetByColorId(int colorıd);
    }
}
