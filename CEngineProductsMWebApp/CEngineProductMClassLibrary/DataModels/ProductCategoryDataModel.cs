using System.Collections.Generic;
using CEngineProductMClassLibrary.Contracts;

namespace CEngineProductMClassLibrary.DataModels
{
    class ProductCategoryDataModel : ICategory
    {
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<IProduct> Products { get; set; }
    }
}
