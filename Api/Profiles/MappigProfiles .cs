using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dto;
using AutoMapper;
using Domain.Entities;

namespace Api.Profiles
{
    public class MappigProfiles : Profile
    {
        public MappigProfiles ()
        {
            CreateMap<Categoriapersona, CategoriaPersonaDto>().ReverseMap();
        }
    }
}