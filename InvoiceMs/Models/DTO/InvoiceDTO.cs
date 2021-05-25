using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Models.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public int UserID { get; set; }
        public bool IsPaid { get; set; }
        public double Sum { get; set; }
        public DateTime RegisterAt { get; set; }
    }
}
