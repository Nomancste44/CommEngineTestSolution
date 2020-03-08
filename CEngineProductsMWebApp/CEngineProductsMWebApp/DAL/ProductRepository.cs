using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CEngineProductsMWebApp.DbContexts;
using CEngineProductMClassLibrary.Contracts;
using CEngineProductMClassLibrary.DataModels;
using CEngineProductsMWebApp.Models;

namespace CEngineProductsMWebApp.DAL
{
    public class ProductRepository : IProductManager
    {
        private CommEngineProductsDbContext _dbContext;
        public ProductRepository(CommEngineProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductDataModel> GetAllProducts()
        {
            var result = _dbContext.Products.Join(_dbContext.ProductCategories
                , x => x.ProductCategoryId
                , y => y.ProductCategoryId
                , (x, y) => new ProductDataModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ExpiredDate = x.ExpiredDate,
                    ManufacturedDate = x.ManufacturedDate,
                    ProductCategoryName = y.CategoryName
                }).ToList();

            return result;
        }

        public IProduct GetAllProducts(int productId)
        {
            var result = _dbContext.Products.Join(_dbContext.ProductCategories
                , x => x.ProductCategoryId
                , y => y.ProductCategoryId
                , (x, y) => new ProductDataModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ExpiredDate = x.ExpiredDate,
                    ManufacturedDate = x.ManufacturedDate,
                    ProductCategoryName = y.CategoryName,
                    ProductCategoryId = y.ProductCategoryId
                }).FirstOrDefault(x=>x.ProductId==productId);

            return result;
        }
        public bool CreateAProduct(IProduct product)
        {
            try
            {
                _dbContext.Products.Add(product as Product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateAProduct(IProduct product)
        {
            var cProduct = product as Product;
            var updatingProduct = _dbContext.Products.FirstOrDefault(x => x.ProductId == cProduct.ProductId);
            if (updatingProduct == null) return false;
            updatingProduct.ExpiredDate = cProduct.ExpiredDate;
            updatingProduct.ManufacturedDate = cProduct.ManufacturedDate;
            updatingProduct.ProductName = cProduct.ProductName;
            updatingProduct.ProductCategoryId = cProduct.ProductCategoryId;
            _dbContext.Entry(cProduct).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}