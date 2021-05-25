using InvoiceMs.DB;
using InvoiceMs.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.DAL
{
    public static class _DAL
    {
        public static async Task<Invoice> Create(Invoice invoiceToAdd)
        {
            using (var db = new InvoiceMsDbContext())
            {
                await db.Invoices.AddAsync(invoiceToAdd);
                await db.SaveChangesAsync();
                return invoiceToAdd;
            }
        }
        public static async Task<Invoice> GetByID(int invoiceID)
        {
            using (var db = new InvoiceMsDbContext())
            {
                Invoice invoice = await db.Invoices.Where(a => a.InvoiceID == invoiceID).FirstOrDefaultAsync();
                return invoice;
            }
        }
        public static async Task<List<Invoice>> GetAllByUserID(int userID)
        {
            using (var db = new InvoiceMsDbContext())
            {
                return await db.Invoices.Where(a => a.UserID == userID).ToListAsync();
            }
        }
        public static async Task<bool> Update(int invoiceID)
        {
            using (var db = new InvoiceMsDbContext())
            {
                Invoice invoiceToUpdate = await db.Invoices.Where(a => a.InvoiceID == invoiceID).FirstOrDefaultAsync();
                if (invoiceToUpdate == null || invoiceToUpdate.IsPaid==true)
                {
                    return false;
                }
                else
                {
                    invoiceToUpdate.IsPaid = true;
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }
        public static async Task<bool> CheckInvoice(int invoiceID)
        {
            using(var db= new InvoiceMsDbContext())
            {
                Invoice invoice = await db.Invoices.Where(a => a.InvoiceID == invoiceID).FirstOrDefaultAsync();
                return invoice.IsPaid;
            }
        }
    }
}
