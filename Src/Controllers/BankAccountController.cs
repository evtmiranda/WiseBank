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
    public async Task<ActionResult<BankAccount>> CreateAsync([FromBody] BankAccountDto bankAccountDto, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.CreateAsync(bankAccountDto, cancellationToken);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = bankAccount.Id, cancellationToken }, bankAccount);
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<ActionResult<BankAccount>> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.GetByIdAsync(id, cancellationToken);
        return Ok(bankAccount);
    }

    [HttpPost("{id}/Deposit")]
    public async Task<ActionResult<BankAccount>> DepositAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 });
    }

    [HttpPost("{id}/Withdraw")]
    public async Task<ActionResult> WithdrawAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 });
    }

    [HttpPost("{id}/Transfer")]
    public async Task<ActionResult> TransferAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 });
    }
}