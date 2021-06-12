using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Helper;
using System.Text.RegularExpressions;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var imageLımıt = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (imageLımıt > 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            var carImageResult = FileHelper.Upload(file);
            if (!carImageResult.Success)
            {
                return new ErrorResult(carImageResult.Message);
            }
            carImage.ImagePath = carImageResult.Message;
            carImage.Date_ = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }



        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image != null)
            {
                FileHelper.Delete(image.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            return new ErrorResult(Messages.CarImageNotFound);



            //var images = _carImageDal.GetAll();

            //foreach (var image in images)
            //{
            //    if (image.Id == carImage.Id)
            //    {
            //       FileHelper.Delete(carImage.ImagePath);
            //        return new SuccessResult();
            //    }


            //}
            //return new ErrorResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carImageId));

        }

        public IDataResult<List<CarImage>> GetCarListByCarID(int carID)
        {
            IResult result = BusinessRules.Run(CarImageCheck(carID));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CarImageCheck(carID).Data);
        }

     //   [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            var updated = FileHelper.Update(file, image.ImagePath);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }
            carImage.ImagePath = updated.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        //BUSINESS RULES
        private IDataResult<List<CarImage>> CarImageCheck(int carId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = carId, ImagePath = path, Date_ = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }

    }

}
