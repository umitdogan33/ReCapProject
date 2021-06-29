using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Business;
using Business.Constans;
using Entities.DTOs;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IResult Add(Customer customer)
        {
           _customerDal.Add(customer);
          return new SuccessResult(Messages.Added);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult("güncelleme işlemi başarılı");
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("silme başarılı");
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(P =>P.Id==id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
           return new SuccessDataResult<List<CustomerDetailDto>>( _customerDal.GetCustomerDetails());
        }
    }
}
