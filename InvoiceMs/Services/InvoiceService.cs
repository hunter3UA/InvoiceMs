using AutoMapper;
using InvoiceMs.DAL;
using InvoiceMs.DataClients;
using InvoiceMs.Mapper;
using InvoiceMs.MessageBus;
using InvoiceMs.Models.DTO;
using InvoiceMs.Models.DTO.External;
using InvoiceMs.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Services
{
    public class InvoiceService:IInvoiceService
    {
        IMapper _mapper;
        public InvoiceService()
        {
            _mapper = AutoMapperConfig.Configure().CreateMapper();
        }
        public async Task<InvoiceDTO> CreateInvoice(int userID)
        { 
            ShoppingCartDTO cart = await ShoppingCartMsClients.GetShoppingCart(userID);
            if (await CheckInvoicesByUserID(userID) || cart.Total==0)
            {
                Invoice invoice = CreateFromCart(cart);
                Invoice invoiceFromDAL = await _DAL.Create(invoice);
                return _mapper.Map<InvoiceDTO>(invoiceFromDAL);
            }
            else
            {
                return new InvoiceDTO();
            }

        }
        public async Task<bool> Pay(int invoiceID)
        {           
            bool isPaid =  await _DAL.Update(invoiceID);
            Invoice invoice = await _DAL.GetByID(invoiceID);
            if (isPaid)
            {
                Producer.InvoicePaid(invoice.ShoppingCartID);
            }
            return isPaid;
        }
        public async Task<List<InvoiceDTO>> GetAllByUserID(int userID)
        {
            List<Invoice> invoicecByUserID = await _DAL.GetAllByUserID(userID);
            return _mapper.Map<List<InvoiceDTO>>(invoicecByUserID);
        }
        public async Task<InvoiceDTO> GetByInvoiceID(int invoiceID)
        {
            Invoice invoice =  await _DAL.GetByID(invoiceID);
            return _mapper.Map<InvoiceDTO>(invoice);
        }
        private static Invoice CreateFromCart(ShoppingCartDTO cart)
        {
            return new Invoice()
            {
                ShoppingCartID = cart.ShoppingCartID,
                UserID = cart.UserID,
                RegisterAt = DateTime.Now,
                Sum = cart.Total,
                IsPaid = false
            };
        }
        private static async Task<bool> CheckInvoicesByUserID(int userID)
        {
            bool isAllPaid = true;
            List<Invoice> invoices= await _DAL.GetAllByUserID(userID);
            foreach (var item in invoices)
            {
                if (item.IsPaid == false)
                {
                    isAllPaid = false;
                }
            }
            return isAllPaid;
        }
      
    }
}
