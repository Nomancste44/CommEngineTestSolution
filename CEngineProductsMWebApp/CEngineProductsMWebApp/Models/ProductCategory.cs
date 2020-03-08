using System.ComponentModel.DataAnnotations;
using CEngineProductMClassLibrary.Contracts;

namespace CEngineProductsMWebApp.Models
{
    public class ProductCategory:ICategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}