using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Models.DTO.External
{
    public class ShoppingCartDTO
    {
        public long ShoppingCartID { get; set; }
        public int UserID { get; set; }
        public double Total { get; set; }
    }
}
