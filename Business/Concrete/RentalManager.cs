using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentaldal.Get(p=> p.CarId== rental.CarId);

            if (result.ReturnDate > DateTime.Now)
            {
               return new ErrorResult("araba henüz teslim edilmemiş");
            }
            else
            {
                _rentaldal.Add(rental);
                return new SuccessResult("başarılı bir şekilde kiralandı");
            }
            
        }

        public IDataResult<List<RentalsDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentaldal.GetAllDetails(),"Listeleme onaylandı");
        }

       

    }
}
