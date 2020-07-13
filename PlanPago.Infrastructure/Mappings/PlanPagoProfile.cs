using AutoMapper;
using PagoPlan.Core.Dtos.PlanPagoDtos;
using PagoPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanPago.Infrastructure.Mappings
{
    public class PlanPagoProfile : Profile
    {
        public PlanPagoProfile()
        {
            CreateMap<Plan, PlanReadDto>().ReverseMap();
            CreateMap<Plan, PlanCreateDto>().ReverseMap();



        }
    }
}
