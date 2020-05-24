using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbCard.Infrastructure.Models;
using DbCard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbCard.Controllers
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