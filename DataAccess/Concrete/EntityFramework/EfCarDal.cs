using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
       

        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var results = from ca in context.Cars
                              join b in context.Brands on ca.BrandId equals b.BrandId
                              join c in context.Colors on ca.ColorId equals c.ColorId
                              select new CarDetailsDto { CarId = ca.CarId,CarName=ca.CarName,BrandName=b.BrandName,ColorName=c.ColorName,DailyPrice=ca.DailyPrice};

                return results.ToList();


                
            }
        }
    }
}
