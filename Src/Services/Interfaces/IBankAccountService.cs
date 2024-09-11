using WiseBank.Src.Entities;
using WiseBank.Src.Services.Dtos;

namespace WiseBank.Src.Services.Interfaces;

public interface IBankAccountService
{
    Task<BankAccount> CreateAsync(BankAccountDto bankAccountDto, CancellationToken cancellationToken);
    Task<BankAccount> GetByIdAsync(int id, CancellationToken cancellationToken);
}