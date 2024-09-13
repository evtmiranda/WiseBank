using Microsoft.EntityFrameworkCore;
using WiseBank.Src.Entities;
using WiseBank.Src.Exceptions;
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

    public async Task<BankAccount> CreateAsync(CreateBankAccountDto createBankAccountDto, CancellationToken cancellationToken)
    {
        var bankAccount = new BankAccount(createBankAccountDto.OwnerName);
        await _wiseBankContext.BankAccounts.AddAsync(bankAccount, cancellationToken);
        await _wiseBankContext.SaveChangesAsync(cancellationToken);
        return bankAccount;
    }

    public async Task<BankAccount?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _wiseBankContext.BankAccounts.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<BankAccount> DepositAsync(DepositDto depositDto, CancellationToken cancellationToken)
    {
        var bankAccount = await GetByIdAsync(depositDto.BankAccountId, cancellationToken);
        if (bankAccount is null)
        {
            throw new BankAccountNotFoundException();
        }
        bankAccount.Deposit(depositDto.Amount);
        return bankAccount;
    }

    public async Task<BankAccount> WithdrawAsync(WithdrawDto withdrawDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<BankAccount> TransferAsync(TransferDto transferDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}