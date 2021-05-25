using InvoiceMs.Models.DTO;
using InvoiceMs.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoiceHistoryController : ControllerBase
    {

        IInvoiceService _serviceInvoice;

        public InvoiceHistoryController(IInvoiceService invoiceService)
        {
            _serviceInvoice = invoiceService;
        }

        // GET: api/<InvoiceHistoryController>
        [HttpGet("userID")]
        public async Task<List<InvoiceDTO>> Get(int userID)
        {
            return await  _serviceInvoice.GetAllByUserID(userID);
        }   
    }
}
