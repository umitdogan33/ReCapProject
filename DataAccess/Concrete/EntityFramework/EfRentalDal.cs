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
                var result = from ren in context.Rentals
                             join ca in context.Cars on ren.CarId equals ca.CarId
                             join ba in context.Brands on ca.BrandId equals ba.BrandId
                             join cl in context.Colors on ca.ColorId equals cl.ColorId
                             join us in context.Users on ren.CustomerId equals us.Id

                             select new RentalsDetailDto
                             {
                                 Id = ren.Id,
                                 CarId = ca.CarId,
                                 DailyPrice = ca.DailyPrice,
                                 RentDate = ren.RentDate,
                                 ReturnDate = ren.ReturnDate,
                                 UserNameLastName = us.FirstName + us.LastName,
                                 TotalPrice = 0,
                                 CarName = ca.CarName,
                                 BrandName = ba.BrandName
                             };





                return result.ToList();
                
            }
            





        }
    }
}
