using InvoiceMs.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.DB
{
    public class InvoiceMsDbContext:DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration appConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            string connString = appConfig.GetConnectionString("InvoiceMsDb");
            optionsBuilder.UseSqlServer(connString);

        }
    }
}
