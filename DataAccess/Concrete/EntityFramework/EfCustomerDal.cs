using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapContext>,ICustomerDal
    {
        
    }
}
