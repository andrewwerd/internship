using DbCard.Infrastructure.DTO.Partner;
using System.Threading.Tasks;

namespace DbCard.Services.Interfaces
{
    public interface IPartnerService
    {
        Task<bool> CreateAsync(PartnerForRegistration partnerDto);
    }
}