namespace WebApi.Services
{
    public interface IFilialService
    {
        Task<Domain.Filial> GetByPhoneAsync(string phoneNumber);
    }
}