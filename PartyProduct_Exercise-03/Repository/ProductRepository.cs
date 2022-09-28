using Microsoft.EntityFrameworkCore;
using PartyProduct_Exercise_03.Data;
using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PartyProductMVCContext _context = null;
        public ProductRepository(PartyProductMVCContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            return await _context.Product
                  .Select(product => new ProductModel()
                  {
                      Id = product.Id,
                      ProductName = product.ProductName
                  }).ToListAsync();
        }

        public async Task<int> ProductAdd(ProductModel productModel)
        {
            var y = _context.Product
                    .Where(x => x.ProductName == productModel.ProductName).FirstOrDefault();

            if (y == null)
            {
                var newProduct = new Product()
                {
                    ProductName = productModel.ProductName
                };

                await _context.Product.AddAsync(newProduct);
                await _context.SaveChangesAsync();

                return newProduct.Id;
            }
            return 0;
        }

        public async Task<int> ProductEditById(int id, ProductModel productModel)
        {
            var y = _context.Product
                    .Where(x => x.ProductName == productModel.ProductName).FirstOrDefault();

            if (y == null)
            {
                var newProduct = new Product()
                {
                    Id = id,
                    ProductName = productModel.ProductName
                };

                _context.Product.Update(newProduct);
                await _context.SaveChangesAsync();
                return newProduct.Id;
            }
            return 0;
        }

        public async Task<bool> ProductDeleteById(int id)
        {
            var y = _context.AssignParty
                   .Where(x => x.ProductId == id).FirstOrDefault();

            var z = _context.ProductRate
                   .Where(x => x.ProductId == id).FirstOrDefault();

            if (y == null && z == null)
            {
                var product = new Product()
                {
                    Id = id
                };
                _context.Product.Remove(product);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
