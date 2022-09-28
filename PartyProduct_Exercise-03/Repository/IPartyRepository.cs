using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public interface IPartyRepository
    {
        Task<List<PartyModel>> GetAllParty();
        Task<int> PartyAdd(PartyModel partyModel);
        Task<int> PartyEditById(int id, PartyModel partyModel);
        Task<bool> PartyDeleteById(int id);
    }
}
