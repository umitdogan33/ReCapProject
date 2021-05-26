using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        
        public IResult Add(Customer car)
        {
            _customerDal.Add(car);
           return new SuccessResult("ekleme işlemi başarılı");
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
           return new SuccessResult("silme işlemi başarılı");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetByUserId(int customer)
        {
            var result = _customerDal.GetAll(p => p.UserId == customer);
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p=> p.Id==Id));
        }
    }
}
