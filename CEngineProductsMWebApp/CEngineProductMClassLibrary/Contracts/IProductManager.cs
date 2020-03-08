using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CEngineProductMClassLibrary.DataModels;

namespace CEngineProductMClassLibrary.Contracts
{
    public interface IProductManager
    {
        List<ProductDataModel> GetAllProducts();
        IProduct GetAllProducts(int productId);
        bool CreateAProduct(IProduct product);
        bool UpdateAProduct(IProduct product);
        bool DeleteAProduct(int productId);
    }
}
