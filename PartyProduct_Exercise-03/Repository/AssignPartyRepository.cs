using Microsoft.EntityFrameworkCore;
using PartyProduct_Exercise_03.Data;
using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public class AssignPartyRepository : IAssignPartyRepository
    {
        private readonly PartyProductMVCContext _context = null;

        public AssignPartyRepository(PartyProductMVCContext context)
        {
            _context = context;
        }

        public async Task<List<AssignPartyModel>> GetAllAssignParty()
        {
            return await _context.AssignParty
                  .Select(assignParty => new AssignPartyModel()
                  {
                      Id = assignParty.Id,
                      PartyId = assignParty.PartyId,
                      ProductId = assignParty.ProductId,
                      Party = assignParty.Party,
                      Product = assignParty.Product
                  }).ToListAsync();
        }

        public async Task<Tuple<int, string, string>> AssignPartyAdd(AssignPartyModel assignPartyModel)
        {
            var y = _context.AssignParty
                    .Where(x => x.PartyId == assignPartyModel.PartyId && x.ProductId == assignPartyModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var newAssignParty = new AssignParty()
                {
                    PartyId = assignPartyModel.PartyId,
                    ProductId = assignPartyModel.ProductId
                };
                await _context.AssignParty.AddAsync(newAssignParty);
                await _context.SaveChangesAsync();

                var party = await _context.Party.FindAsync(assignPartyModel.PartyId);
                var product = await _context.Product.FindAsync(assignPartyModel.ProductId);

                return Tuple.Create(newAssignParty.Id, party.PartyName, product.ProductName);
            }
            return null;
        }

        public async Task<int> AssignPartyEditById(int id, AssignPartyModel assignPartyModel)
        {
            var y = _context.AssignParty
                    .Where(x => x.PartyId == assignPartyModel.PartyId && x.ProductId == assignPartyModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var assignParty = new AssignParty()
                {
                    Id = id,
                    PartyId = assignPartyModel.PartyId,
                    ProductId = assignPartyModel.ProductId
                };
                _context.AssignParty.Update(assignParty);
                await _context.SaveChangesAsync();
                return assignParty.Id;
            }
            return 0;
        }

        public async Task<bool> AssignPartyDeleteById(int id)
        {
            var assignParty = new AssignParty()
            {
                Id = id
            };
            _context.AssignParty.Remove(assignParty);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AssignPartyModel>> GetAllAssignPartyDistinct()
        {
            return await _context.AssignParty
                  .Select(assignParty => new AssignPartyModel()
                  {
                      PartyId = assignParty.PartyId,
                      Party = assignParty.Party,
                  }).Distinct().ToListAsync();
        }
    }
}
