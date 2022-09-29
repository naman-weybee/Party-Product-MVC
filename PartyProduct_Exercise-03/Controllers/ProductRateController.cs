using Microsoft.AspNetCore.Mvc;
using PartyProduct_Exercise_03.Models;
using PartyProduct_Exercise_03.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Controllers
{
    public class ProductRateController : Controller
    {
        private readonly IProductRateRepository _productRateRepository = null;

        public ProductRateController(IProductRateRepository productRateRepository)
        {
            _productRateRepository = productRateRepository;
        }

        public async Task<IActionResult> ProductRate()
        {
            var data = await _productRateRepository.GetAllProductRate();
            return View(data);
        }

        public IActionResult ProductRateAdd(int isSuccess = 0, int productRateId = 0, string productName = null, int productRate = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.productRateId = productRateId;
            ViewBag.productName = productName;
            ViewBag.productRate = productRate;
            ViewBag.IsDisabled = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductRateAdd(ProductRateModel productRateModel)
        {
            if (ModelState.IsValid)
            {
                var model = await _productRateRepository.ProductRateAddNew(productRateModel);
                if (model != null)
                {
                    int id = model.Item1;
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(ProductRateAdd), new { isSuccess = 1, productName = model.Item2, productRate = model.Item3 });
                    }
                }
                return RedirectToAction(nameof(ProductRateAdd), new { isSuccess = 2 });
            }
            return View();
        }

        [HttpGet("EditProductRate/{id}/{productId}/{rate}")]
        public IActionResult ProductRateEdit(int productId, int rate, int isSuccess = 0, [FromRoute] int productRateId = 0)
        {
            ViewBag.IsDisabled = true;
            return View("ProductRateAdd");
        }

        [HttpPost("EditProductRate/{id}/{productId}/{rate}")]
        public async Task<IActionResult> ProductRateEdit([FromRoute] int id, ProductRateModel productRateModel)
        {
            if (ModelState.IsValid)
            {
                int x = await _productRateRepository.ProductRateEditById(id, productRateModel);
                if (x == 0)
                {
                    return RedirectToAction(nameof(ProductRateAdd), new { isSuccess = 2, productRateId = 1 });
                }
            }
            return RedirectToAction("ProductRate");
        }

        public async Task<IActionResult> ProductRateDelete(int id)
        {
            bool isDeleted = await _productRateRepository.ProductRateDeleteById(id);
            if (isDeleted)
            {
                return RedirectToAction("ProductRate");
            }
            return null;
        }
    }
}
