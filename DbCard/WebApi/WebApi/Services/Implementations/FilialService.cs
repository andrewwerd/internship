using Domain;

namespace WebApi.Services.Implementations
{
    public class FilialService: IFilialService
    {
        private readonly IRepository<Filial> _filialRepository;
        public FilialService(IRepository<Filial> filialRepository)
        {
            _filialRepository = filialRepository;
        }
        public async Task<Domain.Filial> GetByPhoneAsync(string phoneNumber)
        {
            return (await _filialRepository.GetByPredicate(p => p.PhoneNumber == phoneNumber)).Single();
        }
    }
}
