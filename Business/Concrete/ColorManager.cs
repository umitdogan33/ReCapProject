using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal _colordal)
        {
            this._colordal = _colordal;
        }

        public void Add(Color entity)
        {
            if (entity.ColorName==null)
            {
                Console.WriteLine("HATA: lütfen Ad veya Günlük ücret tutarını kontrol ediniz.");
            }
            else
            {
                _colordal.Add(entity);
            }
        }

        public void Delete(Color entity)
        {
            _colordal.Delete(entity);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
           return _colordal.Get(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
          return  _colordal.GetAll(filter);
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
