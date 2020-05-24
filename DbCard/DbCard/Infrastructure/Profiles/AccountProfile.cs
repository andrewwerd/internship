using AutoMapper;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Profiles
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            CreateMap<UserForEdit, User>();
            CreateMap<User, UserForEdit>();
        }
    }
}
