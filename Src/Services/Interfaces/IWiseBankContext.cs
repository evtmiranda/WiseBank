using Microsoft.EntityFrameworkCore;
using WiseBank.Src.Entities;

namespace WiseBank.Src.Services.Interfaces;

public interface IWiseBankContext
{
    DbSet<BankAccount> BankAccounts { get; init; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}