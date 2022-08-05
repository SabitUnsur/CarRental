using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int brandID { get; set; }
        public string brandName { get; set; }
    }
}
