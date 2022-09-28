using Microsoft.EntityFrameworkCore;
using PartyProduct_Exercise_03.Data;
using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly PartyProductMVCContext _context = null;

        public PartyRepository(PartyProductMVCContext context)
        {
            _context = context;
        }

        public async Task<List<PartyModel>> GetAllParty()
        {
            return await _context.Party
                  .Select(party => new PartyModel()
                  {
                      Id = party.Id,
                      PartyName = party.PartyName
                  }).ToListAsync();
        }

        public async Task<int> PartyAdd(PartyModel partyModel)
        {
            var y = _context.Party
                    .Where(x => x.PartyName == partyModel.PartyName).FirstOrDefault();

            if (y == null)
            {
                var newParty = new Party()
                {
                    PartyName = partyModel.PartyName
                };

                await _context.Party.AddAsync(newParty);
                await _context.SaveChangesAsync();
                return newParty.Id;
            }
            return 0;
        }

        public async Task<int> PartyEditById(int id, PartyModel partyModel)
        {
            var y = _context.Party
                    .Where(x => x.PartyName == partyModel.PartyName).FirstOrDefault();

            if (y == null)
            {
                var newParty = new Party()
                {
                    Id = id,
                    PartyName = partyModel.PartyName
                };
                _context.Party.Update(newParty);
                await _context.SaveChangesAsync();
                return newParty.Id;
            }
            return 0;
        }

        public async Task<bool> PartyDeleteById(int id)
        {
            var y = _context.AssignParty
                    .Where(x => x.PartyId == id).FirstOrDefault();

            if (y == null)
            {
                var party = new Party()
                {
                    Id = id
                };
                _context.Party.Remove(party);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
