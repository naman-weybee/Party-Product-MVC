using PartyProduct_Exercise_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Repository
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceModel>> GetAllInvoice();
        Task<int> InvoiceAdd(InvoiceModel invoiceModel);
        Task<List<AssignPartyModel>> BindProduct(int PartyId);
        Task<int> BindRate(int ProductId);
        Task ClrearInvoiceAsync();
    }
}
