using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
  public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalsDetailDto> GetAllDetails();
    }
}
