using Microsoft.AspNetCore.Mvc;
using WebApi.Infrastructure.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(
            ITransactionService transactionService
            )
        {
            _transactionService = transactionService;
        }
        [HttpPost("paginatedSearch")]
        public async Task<IActionResult> GetPagedTransactions([FromBody]PagedRequest pagedRequest)
        {
            var pagedTransactionsDto = await _transactionService.GetPagedTransactions(pagedRequest);
            return Ok(pagedTransactionsDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(long id)
        {
            var transaction = await _transactionService.DeleteTransactionAsync(id);
            return Ok(transaction);
        }
    }
}