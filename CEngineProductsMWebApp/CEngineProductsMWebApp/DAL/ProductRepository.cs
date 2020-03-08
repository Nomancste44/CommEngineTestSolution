﻿using System;
using System.Collections.Generic;
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
                   ProductName = x.ProductName,
                   ProductPrice = x.ProductPrice,
                   ExpiredDate = x.ExpiredDate,
                   ManufacturedDate = x.ManufacturedDate,
                    ProductCategoryName = y.CategoryName
                }).ToList();

            return result;
        }

        public bool CreateAProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}