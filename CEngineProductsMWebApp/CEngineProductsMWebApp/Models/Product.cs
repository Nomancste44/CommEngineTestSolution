using System;
using System.ComponentModel.DataAnnotations;
using CEngineProductMClassLibrary.Contracts;
namespace CEngineProductsMWebApp.Models
{
    public class Product :IProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }
    }
}