using AutoMapper;
using InvoiceMs.Models.DTO;
using InvoiceMs.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMs.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceDTO>();
            });
            return config;
        }
    }
}
