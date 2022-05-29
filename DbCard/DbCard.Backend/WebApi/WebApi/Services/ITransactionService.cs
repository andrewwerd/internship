using Domain;
using WebApi.Infrastructure.DTO.Transaction;
using WebApi.Infrastructure.Models;

namespace WebApi.Services
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(Domain.Customer customer, Domain.Filial filial, decimal amount, DateTime? date = null);

        Task<Transaction> DeleteTransactionAsync(long id);

        Task<PaginatedResult<TransactionGridRow>> GetPagedTransactions(PagedRequest pagedRequest);
    }
}
