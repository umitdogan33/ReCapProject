using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int Id);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetByUserId(int customer);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
    }
}
