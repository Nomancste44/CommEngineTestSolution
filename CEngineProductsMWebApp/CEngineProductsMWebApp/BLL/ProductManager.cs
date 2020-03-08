using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using CEngineProductMClassLibrary.Contracts;
using CEngineProductMClassLibrary.DataModels;

namespace CEngineProductsMWebApp.BLL
{
    public class ProductManager:IProductManager
    {
        private readonly IProductManager _productRepository;
        [InjectionConstructor]
        public ProductManager(IProductManager productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductDataModel> GetAllProducts()
        {
            //Checking some business logic & apply 
            return _productRepository.GetAllProducts();
        }
        public IProduct GetAllProducts(int productId)
        {
            //Checking some business logic & apply 
            return _productRepository.GetAllProducts(productId);
        }
        public bool CreateAProduct(IProduct product)
        {
           return _productRepository.CreateAProduct(product);
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