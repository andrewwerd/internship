using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IFilialService
    {
        Task<Domain.Filial> GetByPhoneAsync(string phoneNumber);
    }
}