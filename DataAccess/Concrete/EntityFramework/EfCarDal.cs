using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,NorthwindContext>,ICarDal
    {
       public List<CarDetailDto> GetCarDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from c in context.Car
                             join b in context.Brands
                             on c.BrandID equals b.ID
                             join p in context.Colors
                             on c.ColorID equals p.ID

                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = p.ColorName,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
                
            }
        }
    }
}
