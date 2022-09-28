using Microsoft.AspNetCore.Mvc;
using PartyProduct_Exercise_03.Models;
using PartyProduct_Exercise_03.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Controllers
{
    public class AssignPartyController : Controller
    {
        private readonly IAssignPartyRepository _assignPartyRepository = null;

        public AssignPartyController(IAssignPartyRepository assignPartyRepository)
        {
            _assignPartyRepository = assignPartyRepository;
        }

        public async Task<IActionResult> AssignParty()
        {
            var data = await _assignPartyRepository.GetAllAssignParty();
            return View(data);
        }

        public IActionResult AssignPartyAdd(int isSuccess = 0, int assignPartyId = 0, string assignParty = null, string assignProduct = null)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.assignPartyId = assignPartyId;
            ViewBag.assignParty = assignParty;
            ViewBag.assignProduct = assignProduct;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignPartyAdd(AssignPartyModel assignPartyModel)
        {
            if (ModelState.IsValid)
            {
                var model = await _assignPartyRepository.AssignPartyAdd(assignPartyModel);
                if (model != null)
                {
                    int id = model.Item1;
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(AssignPartyAdd), new { isSuccess = 1, isFailed = false, assignParty = model.Item2, assignProduct = model.Item3 });
                    }
                }
                return RedirectToAction(nameof(AssignPartyAdd), new { isSuccess = 2 });
            }
            return View();
        }

        [HttpGet("EditAssignParty/{id}/{partyId}/{productId}")]
        public IActionResult AssignPartyEdit(int partyId, int productId, int isSuccess = 0, [FromRoute] int assignPartyId = 0)
        {
            return View("AssignPartyAdd");
        }

        [HttpPost("EditAssignParty/{id}/{partyId}/{productId}")]
        public async Task<IActionResult> AssignPartyEdit([FromRoute] int id, AssignPartyModel assignPartyModel)
        {
            if (ModelState.IsValid)
            {
                int x = await _assignPartyRepository.AssignPartyEditById(id, assignPartyModel);
                if (x == 0)
                {
                    return RedirectToAction(nameof(AssignPartyAdd), new { isSuccess = 2, assignPartyId = 1 });
                }
            }
            return RedirectToAction("AssignParty");
        }

        public async Task<IActionResult> AssignPartyDelete(int id)
        {
            bool isDeleted = await _assignPartyRepository.AssignPartyDeleteById(id);
            if (isDeleted)
            {
                return RedirectToAction("AssignParty");
            }
            return null;
        }
    }
}
