using WiseBank.Src.Entities;
using WiseBank.Src.Services.Dtos;

namespace WiseBank.Src.Services.Interfaces;

public interface IBankAccountService
{
    Task<BankAccount> CreateAsync(CreateBankAccountDto createBankAccountDto, CancellationToken cancellationToken);
    Task<BankAccount?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<BankAccount> DepositAsync(DepositDto depositDto, CancellationToken cancellationToken);
    Task<BankAccount> WithdrawAsync(WithdrawDto withdrawDto, CancellationToken cancellationToken);
    Task<BankAccount> TransferAsync(TransferDto transferDto, CancellationToken cancellationToken);
}