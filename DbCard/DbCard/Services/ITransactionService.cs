using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(Domain.Customer customer, Domain.Filial filial, decimal amount);
        Task CreateTransactionAsync(Domain.Customer customer, Domain.Filial filial, decimal amount, DateTime date);
    }
}
