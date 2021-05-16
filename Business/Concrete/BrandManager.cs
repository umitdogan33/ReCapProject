using Business.Abstract;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _branddal;

        public BrandManager(IBrandDal branddal)
        {
            _branddal = branddal;
        }

        public IResult Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
