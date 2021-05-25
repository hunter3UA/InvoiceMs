using InvoiceMs.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDTO>> GetAllByUserID(int userID);
        Task<InvoiceDTO> GetByInvoiceID(int invoiceID);
        Task<InvoiceDTO> CreateInvoice(int userID);
        Task<bool> Pay(int invoiceID);
    }
}
