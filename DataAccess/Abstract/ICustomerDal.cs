using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
   public interface ICustomerDal:IEntityRepository<Customer>
   {
       List<CustomerDetailDto> GetCustomerDetails();
   }
}
