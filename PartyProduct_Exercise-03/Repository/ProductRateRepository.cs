using Microsoft.EntityFrameworkCore;
using PartyProduct_Exercise_03.Data;
using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public class ProductRateRepository : IProductRateRepository
    {
        private readonly PartyProductMVCContext _context = null;

        public ProductRateRepository(PartyProductMVCContext context)
        {
            _context = context;
        }

        public async Task<List<ProductRateModel>> GetAllProductRate()
        {
            return await _context.ProductRate
                .Select(productRate => new ProductRateModel()
                {
                    Id = productRate.Id,
                    ProductId = productRate.ProductId,
                    Product = productRate.Product,
                    Rate = productRate.Rate,
                    DateOfRate = productRate.DateOfRate
                }).ToListAsync();
        }

        public async Task<Tuple<int, string, int>> ProductRateAddNew(ProductRateModel productRateModel)
        {
            var y = _context.ProductRate
                    .Where(x => x.ProductId == productRateModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var productRate = new ProductRate()
                {
                    ProductId = productRateModel.ProductId,
                    Rate = productRateModel.Rate,
                    DateOfRate = DateTime.Now
                };

                await _context.ProductRate.AddAsync(productRate);
                await _context.SaveChangesAsync();

                var product = await _context.Product.FindAsync(productRateModel.ProductId);

                return Tuple.Create(productRate.Id, product.ProductName, productRateModel.Rate);
            }
            return null;
        }

        public async Task<int> ProductRateEditById(int id, ProductRateModel productRateModel)
        {
            var y = _context.ProductRate
                    .Where(x => x.ProductId == productRateModel.ProductId && x.Rate == productRateModel.Rate).FirstOrDefault();

            if (y == null)
            {
                var productRate = new ProductRate()
                {
                    Id = id,
                    ProductId = productRateModel.ProductId,
                    Rate = productRateModel.Rate,
                    DateOfRate = DateTime.Now
                };

                _context.ProductRate.Update(productRate);
                await _context.SaveChangesAsync();
                return productRate.Id;
            }
            return 0;
        }

        public async Task<bool> ProductRateDeleteById(int id)
        {
            var productRate = new ProductRate()
            {
                Id = id
            };
            _context.ProductRate.Remove(productRate);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
