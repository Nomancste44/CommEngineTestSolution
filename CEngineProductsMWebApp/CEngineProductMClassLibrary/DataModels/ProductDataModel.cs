using System;
using CEngineProductMClassLibrary.Contracts;

namespace CEngineProductMClassLibrary.DataModels
{
    public class ProductDataModel : IProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public double ProductPrice { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
