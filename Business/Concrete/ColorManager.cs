using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colordal.Add(color);
           return new SuccessResult("ekleme başarılı");
        }

        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
           var result = _colordal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetById(int Id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(p=> p.ColorId==Id));
        }

        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
