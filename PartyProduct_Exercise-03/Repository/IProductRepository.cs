using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProduct();
        Task<int> ProductAdd(ProductModel productModel);
        Task<int> ProductEditById(int id, ProductModel productModel);
        Task<bool> ProductDeleteById(int id);
    }
}
