using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Helpers.FileHelper.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(GetCheckCarImageLimit(carImage.CarId));
            if(result!=null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.CarImagesPath, carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAllImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetImageById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId), Messages.ImagesListedById);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(GetCheckImageExist(carId));
            if(result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId), Messages.ImagesListedByCarId);
        }

        private IResult GetCheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }

        private IResult GetCheckImageExist(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result == 0)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "Default.jpg" });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }


    }
}
