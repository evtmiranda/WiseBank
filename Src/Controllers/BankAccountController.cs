using Microsoft.AspNetCore.Mvc;
using WiseBank.Src.Entities;
using WiseBank.Src.Services.Dtos;
using WiseBank.Src.Services.Interfaces;

namespace WiseBank.Src.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly IBankAccountService _bankAccountService;

    public BankAccountController(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    [HttpPost]
    public async Task<ActionResult<BankAccount>> CreateAsync([FromBody] CreateBankAccountDto createBankAccountDto, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.CreateAsync(createBankAccountDto, cancellationToken);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = bankAccount.Id, cancellationToken }, bankAccount);
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<ActionResult<BankAccount>> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.GetByIdAsync(id, cancellationToken);
        if (bankAccount is null)
        {
            return NotFound();
        }
        return Ok(bankAccount);
    }

    [HttpPost("{id}/Deposit")]
    public async Task<ActionResult<BankAccount>> DepositAsync([FromRoute] int id, [FromBody] DepositDto depositDto, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.DepositAsync(id, depositDto, cancellationToken);
        return Ok(bankAccount);
    }

    [HttpPost("{id}/Withdraw")]
    public async Task<ActionResult> WithdrawAsync([FromRoute] int id, [FromBody] WithdrawDto withdrawDto, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.WithdrawAsync(id, withdrawDto, cancellationToken);
        return Ok(bankAccount);
    }

    [HttpPost("{id}/Transfer")]
    public async Task<ActionResult> TransferAsync([FromRoute] int id, [FromBody] TransferDto transferDto, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.TransferAsync(id, transferDto, cancellationToken);
        return Ok(bankAccount);
    }
}