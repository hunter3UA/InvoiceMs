using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public long ShoppingCartID { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        [Required]
        public double Sum { get; set; }
        [Required]
        public DateTime RegisterAt { get; set; }
    }
}
