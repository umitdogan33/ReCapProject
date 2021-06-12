using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalsDetailDto> GetAllDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                   var result = from c in context.Rentals
                             join ax in context.Cars on c.CarId equals ax.CarId
                             join ac in context.Brands on ax.BrandId equals ac.BrandId
                             join cl in context.Colors on ax.ColorId equals cl.ColorId
                             join cs in context.Customers on c.CustomerId equals cs.Id
                             join us in context.Users on cs.UserId equals us.Id

                             select new RentalsDetailDto
                             {
                                  Id=c.Id,   
                                 BrandName = ac.BrandName,
                                 CustomerLastName=us.LastName,
                                 CustomerName=us.FirstName,
                                 DailyPrice = ax.DailyPrice,
                                 Email = us.Email,
                                 ModelYear = ax.ModelYear,
                                 RentDate = c.RentDate,
                                 ReturnDate = c.ReturnDate
                             };





                return result.ToList();
                
            }
            





        }
    }
}
