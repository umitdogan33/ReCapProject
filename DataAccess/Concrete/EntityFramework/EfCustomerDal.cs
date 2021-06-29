using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result =
                    from u in context.Users
                    join c in context.Customers on u.Id equals c.UserId
                    select new CustomerDetailDto
                    {
                        Id = c.Id,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName

                    };
                return result.ToList();

            }
        }
    }
}
