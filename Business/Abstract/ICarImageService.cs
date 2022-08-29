using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddImage(IFormFile formFile,CarImage addImage);
        IResult DeleteImage(CarImage deleteImage);
        IResult UpdateImage(IFormFile formFile,CarImage updateImage);
       
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetByImageId(int imageId);



    }
}
