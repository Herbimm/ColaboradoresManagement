using AutoMapper;
using ColaboradoresManagement.Domain.Dto;
using ColaboradoresManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.CrossCutting.Utis
{
    public class ColaboradoresManagementAutoMapperProfile : Profile
    {
        public ColaboradoresManagementAutoMapperProfile()
        {
            CreateMap<Colaborador, ColaboradorDto>().ReverseMap();
        }
    }
}
