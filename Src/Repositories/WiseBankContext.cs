using Microsoft.EntityFrameworkCore;
using WiseBank.Src.Entities;
using WiseBank.Src.Services.Interfaces;

namespace WiseBank.Src.Repositories;

public class WiseBankContext : DbContext, IWiseBankContext
{
    public WiseBankContext(DbContextOptions<WiseBankContext> options)
        : base(options)
    {

    }

    public DbSet<BankAccount> BankAccounts { get; init; }
}