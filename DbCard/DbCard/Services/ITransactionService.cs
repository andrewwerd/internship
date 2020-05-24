using DbCard.Infrastructure.Dto.Transaction;
using DbCard.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbCard.Domain;

namespace DbCard.Services
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(Domain.Customer customer, Domain.Filial filial, decimal amount, DateTime? date = null);

        Task<Transaction> DeleteTransactionAsync(long id);

        Task<PaginatedResult<TransactionGridRow>> GetPagedTransactions(PagedRequest pagedRequest);
    }
}
