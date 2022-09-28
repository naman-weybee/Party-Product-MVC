using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public interface IAssignPartyRepository
    {
        Task<List<AssignPartyModel>> GetAllAssignParty();
        Task<Tuple<int, string, string>> AssignPartyAdd(AssignPartyModel assignPartyModel);
        Task<int> AssignPartyEditById(int id, AssignPartyModel assignPartyModel);
        Task<bool> AssignPartyDeleteById(int id);
        Task<List<AssignPartyModel>> GetAllAssignPartyDistinct();
    }
}
