using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CEngineProductsMWebApp.Models;
using CEngineProductsMWebApp.DAL;
using CEngineProductsMWebApp.BLL;
using CEngineProductMClassLibrary.Contracts;
using CEngineProductsMWebApp.DbContexts;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace CEngineProductsMWebApp.Controllers
{
    public class ProductsController : ApiController
    {
        readonly ProductManager _productManager;
        public ProductsController()
        {
            var container = new UnityContainer();
            container.RegisterType<ProductRepository>(new InjectionConstructor(new CommEngineProductsDbContext()));
            container.RegisterType<IProductManager, ProductRepository>(new ContainerControlledLifetimeManager());
            
            _productManager = container.Resolve<ProductManager>();
        }
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
           
            return Ok(_productManager.GetAllProducts());
        }

        public IHttpActionResult GetAProduct(int productId)
        {

            return Ok(_productManager.GetAllProducts(productId));
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid || !_productManager.CreateAProduct(product))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request"));
            
            return Ok(_productManager.GetAllProducts());
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(Product product)
        {
            return Ok();
        }
    }
}
