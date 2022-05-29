using Domain.Auth;
using WebApi.Infrastructure.DTO.Filial;
using WebApi.Infrastructure.DTO.News;
using WebApi.Infrastructure.DTO.Partner;
using WebApi.Infrastructure.Models;
using WebApi.Models.Charts;

namespace WebApi.Services
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
        Task<IEnumerable<Filial>> GetFilials(long id);
        Task<IEnumerable<News>> GetNews(long id);

        Task<ChartData<int>> GetWeeklyAverageStatistic();
        Task<ChartData<decimal>> GetAgeStatistic();
        Task<ChartData<int>> GetGenderStatistic();
    }
}