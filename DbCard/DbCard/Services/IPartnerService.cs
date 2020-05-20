using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Partner;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IPartnerService
    {
        Task<bool> CreateAsync(Domain.Partner partner, User user);
        Task<bool> CreateFromDtoAsync(PartnerForRegistration partnerDto, User user);
        Task<Infrastructure.Dto.Partner.Partner> GetCurrentUser();
        Task AddToCategory(Domain.Partner partner, string categoryName);
        Task AddToSubcategory(Domain.Partner partner, string subcategoryName);
        Task<long> GetIdByName(string name);
    }
}