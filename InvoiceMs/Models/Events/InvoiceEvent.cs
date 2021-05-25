using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Models.Events
{
    public class InvoiceEvent
    {
        public string EventType { get; set; }
        public string PayLoad { get; set; }
    }
}
