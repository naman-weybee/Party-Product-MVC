using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public interface IProductRateRepository
    {
        Task<List<ProductRateModel>> GetAllProductRate();
        Task<Tuple<int, string, int>> ProductRateAddNew(ProductRateModel productRateModel);
        Task<int> ProductRateEditById(int id, ProductRateModel productRateModel);
        Task<bool> ProductRateDeleteById(int id);
    }
}
