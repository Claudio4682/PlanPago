using AutoMapper;
using PagoPlan.Core.Dtos.ClienteDtos;
using PagoPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanPago.Infrastructure.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDto>().ReverseMap();
        }
    }
}
