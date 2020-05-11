using DbCard.Infrastructure.Dto.Partner;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IPartnerService
    {
        Task<bool> CreateAsync(PartnerForRegistration partnerDto);
    }
}