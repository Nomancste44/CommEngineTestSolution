using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEngineProductMClassLibrary.Contracts
{
    public interface ICategoryManager
    {
        List<ICategory> GetAllCategoriess();
        bool CreateACategory(ICategory category);
        bool UpdateACategory(ICategory category);
        bool DeleteACategory(int categoryId);
    }
}
