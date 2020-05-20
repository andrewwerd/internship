using DbCard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
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
