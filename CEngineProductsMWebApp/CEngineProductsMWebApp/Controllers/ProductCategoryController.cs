using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CEngineProductsMWebApp.DbContexts;

namespace CEngineProductsMWebApp.Controllers
{
    public class ProductCategoryController : ApiController
    {
        CommEngineProductsDbContext _dbContext = new CommEngineProductsDbContext();

        [HttpGet]
        public IHttpActionResult GetAllProductCategories()
        {
            return Ok(_dbContext.ProductCategories.ToList());
        }

    }
}
