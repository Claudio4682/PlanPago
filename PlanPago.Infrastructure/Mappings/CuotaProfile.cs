using AutoMapper;
using PagoPlan.Core.Dtos.CuotaDtos;
using PagoPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanPago.Infrastructure.Mappings
{
    class CuotaProfile : Profile
    {
        public CuotaProfile()
        {
            CreateMap<Cuota, CuotaDto>().ReverseMap();
            CreateMap<Cuota, CuotaCreateDto>().ReverseMap();

        }
    }
}
