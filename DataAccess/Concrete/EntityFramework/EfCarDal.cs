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
       

        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var results = from ca in filter == null ? context.Cars : context.Cars.Where(filter)

                              join b in context.Brands on ca.BrandId equals b.BrandId
                              join c in context.Colors on ca.ColorId equals c.ColorId
                              select new CarDetailsDto 
                              {
                              Id=ca.CarId,CarName=ca.CarName,
                              BrandName=b.BrandName,
                              ModelYear=ca.ModelYear,
                              BrandId=b.BrandId,
                              ColorId=c.ColorId,
                              Description= ca.Description,
                              CarId=ca.CarId,
                              ColorName=c.ColorName,
                              DailyPrice=ca.DailyPrice,
                              Images =
                              (from i in context.CarImages where i.CarId == ca.CarId select i.ImagePath).ToList()
                              };

                return results.ToList();


                
            }
        }

        public CarDetailsDto GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var results = from ca in filter == null ? context.Cars : context.Cars.Where(filter)

                              join b in context.Brands on ca.BrandId equals b.BrandId
                              join c in context.Colors on ca.ColorId equals c.ColorId
                              select new CarDetailsDto
                              {
                                  Id = ca.CarId,
                                  CarName = ca.CarName,
                                  BrandName = b.BrandName,
                                  ModelYear = ca.ModelYear,
                                  BrandId = b.BrandId,
                                  ColorId = c.ColorId,
                                  Description = ca.Description,
                                  CarId = ca.CarId,
                                  ColorName = c.ColorName,
                                  DailyPrice = ca.DailyPrice,
                                  Images =
                              (from i in context.CarImages where i.CarId == ca.CarId select i.ImagePath).ToList()
                              };
                return results.FirstOrDefault();

            }
        }

    }
}
