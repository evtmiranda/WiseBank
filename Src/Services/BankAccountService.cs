using Microsoft.EntityFrameworkCore;
using WiseBank.Src.Entities;
using WiseBank.Src.Services.Dtos;
using WiseBank.Src.Services.Interfaces;

namespace WiseBank.Src.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IWiseBankContext _wiseBankContext;

    public BankAccountService(IWiseBankContext wiseBankContext)
    {
        _wiseBankContext = wiseBankContext;
    }

    public async Task<BankAccount> CreateAsync(BankAccountDto bankAccountDto, CancellationToken cancellationToken)
    {
        var bankAccount = new BankAccount(bankAccountDto.OwnerName);
        await _wiseBankContext.BankAccounts.AddAsync(bankAccount, cancellationToken);
        await _wiseBankContext.SaveChangesAsync(cancellationToken);
        return bankAccount;
    }

    public async Task<BankAccount> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _wiseBankContext.BankAccounts.FirstAsync(b => b.Id == id);
    }

    public async Task DepositAsync(CancellationToken cancellationToken)
    {

    }

    public async Task WithdrawAsync(CancellationToken cancellationToken)
    {

    }

    public async Task TransferAsync(BankAccount source, BankAccount target, CancellationToken cancellationToken)
    {

    }
}