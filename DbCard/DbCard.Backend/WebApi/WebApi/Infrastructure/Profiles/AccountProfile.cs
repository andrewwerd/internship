using AutoMapper;
using Domain.Auth;
using WebApi.Infrastructure.DTO.Account;

namespace WebApi.Infrastructure.Profiles
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
