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

    public async Task<BankAccount> GetByIdAsync(int bankAccountId, CancellationToken cancellationToken)
    {
        var bankAccount = await _wiseBankContext.BankAccounts.FirstOrDefaultAsync(b => b.Id == bankAccountId, cancellationToken);
        if (bankAccount is null)
        {
            throw new BankAccountNotFoundException($"Nenhuma conta bancária com o id {bankAccountId} foi encontrada.");
        }
        return bankAccount;
    }

    public async Task<BankAccount> DepositAsync(int bankAccountId, DepositDto depositDto, CancellationToken cancellationToken)
    {
        var bankAccount = await GetByIdAsync(bankAccountId, cancellationToken);
        bankAccount.Deposit(depositDto.Amount);
        await _wiseBankContext.SaveChangesAsync(cancellationToken);
        return bankAccount;
    }

    public async Task<BankAccount> WithdrawAsync(int bankAccountId, WithdrawDto withdrawDto, CancellationToken cancellationToken)
    {
        var bankAccount = await GetByIdAsync(bankAccountId, cancellationToken);
        bankAccount.Withdraw(withdrawDto.Amount);
        await _wiseBankContext.SaveChangesAsync(cancellationToken);
        return bankAccount;
    }

    public async Task<BankAccount> TransferAsync(int bankAccountId, TransferDto transferDto, CancellationToken cancellationToken)
    {
        var sourceBankAccount = await GetByIdAsync(bankAccountId, cancellationToken);
        var targetBankAccount = await GetByIdAsync(transferDto.TargetBankAccountId, cancellationToken);
        sourceBankAccount.Withdraw(transferDto.Amount);
        targetBankAccount.Deposit(transferDto.Amount);
        await _wiseBankContext.SaveChangesAsync(cancellationToken);
        return sourceBankAccount;
    }
}