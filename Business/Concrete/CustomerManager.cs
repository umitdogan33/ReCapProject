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
            IResult result = BusinessRules.Run(SameCustomerName(car.UserId));

            if (result != null)
            {
                return result;
            }

            _customerDal.Add(car);
            return new SuccessResult(Messages.Addedustomer);



            //return new SuccessResult("ekleme işlemi başarılı");
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

        private IResult SameCustomerName(int Userıd)
        {
            var result = _customerDal.GetAll(p => p.UserId == Userıd).Any();
            if (result)
            {
                return new ErrorResult("aynı isimde kullanıcı var");
            }

            return new SuccessResult();
        }
       
        
        
    }
}
