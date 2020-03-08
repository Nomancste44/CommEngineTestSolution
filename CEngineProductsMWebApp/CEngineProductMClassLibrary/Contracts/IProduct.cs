using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEngineProductMClassLibrary.Contracts
{
    public interface IProduct
    {
         string ProductName { get; set; }
         DateTime ManufacturedDate { get; set; }
         DateTime ExpiredDate { get; set; }
         double ProductPrice { get; set; }
    }
}
