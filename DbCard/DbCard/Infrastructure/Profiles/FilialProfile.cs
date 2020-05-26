using AutoMapper;
using DbCard.Infrastructure.Dto.Filial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Profiles
{
    public class FilialProfile: Profile
    {
        public FilialProfile()
        {
            CreateMap<Domain.Filial, Filial>();
            CreateMap<Filial, Domain.Filial>();
        }
    }
}
