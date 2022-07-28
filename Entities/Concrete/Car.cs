using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {   public int ID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public Decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string Name { get; set; }
    }
}
