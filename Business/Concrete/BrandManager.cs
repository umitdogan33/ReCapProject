using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _branddal;

        public BrandManager(IBrandDal branddal)
        {
            _branddal = branddal;
        }

        public void Add(Brand entity)
        {
            if (entity.BrandName==null)
            {
                Console.WriteLine("alanlar boş bırakılamaz");
            }
            else
            {
                _branddal.Add(entity);
            }
        }

        public void Delete(Brand entity)
        {
            _branddal.Delete(entity);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _branddal.Get(filter);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _branddal.GetAll();
        }

        public void Update(Brand entity)
        {
            if (entity.BrandName==null)
            {
                Console.WriteLine("istenilen alanlar boş bırakılamaz");
            }
            else
            {
                _branddal.Update(entity);
            }
        }
    }
}
