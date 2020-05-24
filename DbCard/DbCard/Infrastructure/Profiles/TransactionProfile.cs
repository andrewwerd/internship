using AutoMapper;
using DbCard.Infrastructure.Dto.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Profiles
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<Domain.Transaction, TransactionGridRow>()
                .ForMember(x => x.Category, e => e.MapFrom(p => p.Category.Name))
                .ForMember(x => x.Subcategory, e => e.MapFrom(p => p.Subcategory.Name));
        }
    }
}
