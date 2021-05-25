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
    public class InvoiceController : ControllerBase
    {
        IInvoiceService _service;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _service = invoiceService;
        }
  
        // POST api/v1/<InvoiceController>
        [HttpPost]
        public async Task<InvoiceDTO> Post([FromBody] CreateInvoiceDTO createAccountDTO)
        {
            return await _service.CreateInvoice(createAccountDTO.UserID);
        }
        // PUT api/v1/<InvoiceController>
        [HttpPut]
        public async Task<bool> Put(int invoiceID)
        {
            return await _service.Pay(invoiceID);
        }
        // GET api/v1/<InvoiceController>
        [HttpGet("invoiceID")]
        public async Task<InvoiceDTO> Get(int invoiceID)
        {
            return await _service.GetByInvoiceID(invoiceID);
        }
    }
}
