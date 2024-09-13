namespace WiseBank.Src.Entities;

public class BankAccount
{
    public BankAccount(string ownerName)
    {
        OwnerName = ownerName;
    }

    public int Id { get; init; }
    public string OwnerName { get; init; }
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("O valor do depósito deve ser maior do que zero");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior do que zero");
        }

        if (amount > Balance)
        {
            throw new ArgumentException($"Saldo insuficiente. O saldo disponível em conta é R$ {Balance}");
        }

        Balance -= amount;
    }
}