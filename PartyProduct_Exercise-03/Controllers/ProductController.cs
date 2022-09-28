using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using PartyProduct_Exercise_03.Models;
using PartyProduct_Exercise_03.Repository;

namespace PartyProduct_Exercise_03.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository = null;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Product(bool delete = false)
        {
            ViewBag.delete = delete;
            var data = await _productRepository.GetAllProduct();
            return View(data);
        }

        public IActionResult ProductAdd(int isSuccess = 0, int productId = 0, string productName = null)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.productId = productId;
            ViewBag.productName = productName;
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> ProductAdd(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _productRepository.ProductAdd(productModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(ProductAdd), new { isSuccess = 1, productName = productModel.ProductName });
                }
                else
                {
                    return RedirectToAction(nameof(ProductAdd), new { isSuccess = 2 });
                }
            }
            return View();
        }

        [HttpGet("EditProduct/{id}/{productName}")]
        public IActionResult ProductEdit(string productName, int isSuccess = 0, [FromRoute] int productId = 0)
        {
            return View("ProductAdd");
        }

        [HttpPost("EditProduct/{id}/{productName}")]
        public async Task<IActionResult> ProductEdit([FromRoute] int id, ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                int x = await _productRepository.ProductEditById(id, productModel);
                if (x == 0)
                {
                    return RedirectToAction(nameof(ProductAdd), new { isSuccess = 2, productId = 1 });
                }
            }
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            bool isDeleted = await _productRepository.ProductDeleteById(id);
            if (isDeleted)
            {
                return RedirectToAction("Product");
            }
            return RedirectToAction(nameof(Product), new { delete = true });
        }
    }
}
