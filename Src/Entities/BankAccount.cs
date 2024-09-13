namespace WiseBank.Src.Entities;

public class BankAccount
{
    public BankAccount(string ownerName)
    {
        OwnerName = ownerName;
        Balance = 0;
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
}