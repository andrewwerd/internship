using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IPartnerService
    {
        Task<bool> CreateAsync(Domain.Partner partner, User user);
        Task<bool> CreateFromDtoAsync(PartnerForRegistration partnerDto, User user);
        Task<Partner> GetCurrentPartner();
        Task AddToCategory(Domain.Partner partner, string categoryName);
        Task AddToSubcategory(Domain.Partner partner, string subcategoryName);
        Task<long> GetIdByName(string name);
        Task<IEnumerable<PartnerGridRow>> GetPartnerGridRows(PagedRequest scrollRequest);
        Task<Partner> GetPartner(long id);
        Task<IEnumerable<Infrastructure.Dto.Filial.Filial>> GetFilials(long id);
        Task<IEnumerable<Infrastructure.Dto.News.News>> GetNews(long id);
    }
}