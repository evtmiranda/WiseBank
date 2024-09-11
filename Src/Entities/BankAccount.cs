namespace WiseBank.Src.Entities;

public class BankAccount
{
    public BankAccount(string ownerName)
    {
        OwnerName = ownerName;
    }

    public int Id { get; init; }
    public string OwnerName { get; init; }
}