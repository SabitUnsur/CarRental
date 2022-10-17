using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper= fileHelper;
        }

        public IResult AddImage(IFormFile formFile,CarImage addImage)
        {
            BusinessRules.Run(CheckIfImageLimitExceded(addImage.CarId));
            addImage.ImagePath = _fileHelper.Add(formFile, PathConstans.ImagesRoot);
            addImage.Date = DateTime.Now;
            _carImageDal.Add(addImage);
            return new SuccessResult(Messages.SuccessUploadOfCarImage);
        }

        public IResult DeleteImage(CarImage deleteImage)
        {
            _fileHelper.Delete(PathConstans.ImagesRoot+deleteImage.ImagePath);
            _carImageDal.Delete(deleteImage);
            return new SuccessResult(Messages.CarImageDeletedSuccessfully);
        }

        public IResult UpdateImage(CarImage updateImage, IFormFile formFile)
        {
            updateImage.ImagePath = _fileHelper.Update(formFile, PathConstans.ImagesRoot + updateImage.ImagePath, PathConstans.ImagesRoot);
            updateImage.Date = DateTime.Now;
            _carImageDal.Update(updateImage);
            return new SuccessResult(Messages.CarImageUpdatedSuccesfully);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarHasImage(carId));

            if(result==null)
            {
                return new ErrorDataResult<List<CarImage>>(DefaultCarImage(carId).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetByImageId(int imageId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == imageId));
        }

        private IResult CheckIfImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if(result.Count<=5) { return new SuccessResult(); }

            return new ErrorResult();

        }

        private IResult CheckIfCarHasImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IDataResult<List<CarImage>> DefaultCarImage(int carId)
        {
            List<CarImage> defaultCarImages = new List<CarImage>();
            defaultCarImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(defaultCarImages);
        }

        public IResult UpdateImage(IFormFile formFile, CarImage updateImage)
        {
            throw new NotImplementedException();
        }
    }
}
