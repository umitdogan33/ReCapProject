using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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







        // [ValidationAspect(typeof(BrandValidator))]
        //[CacheRemoveAspect("get")]
        //[TransactionScopeAspect]
        public IResult Add(Brand brand)
        {
            IResult Result = BusinessRules.Run(SameBrandName(brand.BrandName));
            if (Result != null)
            {
                return Result;
            }
            _branddal.Add(brand);
            return new SuccessResult(Messages.AddedBrand);
            
        }

        public IResult Delete(Brand brand)
        {
            _branddal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

      
        
        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult<List<Brand>>(_branddal.GetAll());
        }


        public IDataResult<Brand> GetById(int Id)
        {
            return new SuccessDataResult<Brand>(_branddal.Get(p => p.BrandId == Id));
        }

        public IResult Update(Brand brand)
        {
            _branddal.Update(brand);
            return new SuccessResult(Messages.Updated);
            
        }

        private IResult SameBrandName(string brand)
        {
            var result = _branddal.GetAll(p => p.BrandName == brand).Any();
            if (result)
            {
                return new ErrorResult(Messages.SameBrandName);
            }

            return new SuccessResult(Messages.AddedBrand);
        }
    }
}
