namespace WiseBank.Src.Exceptions;

public class BankAccountNotFoundException : Exception
{
    public BankAccountNotFoundException()
    {
    }

    public BankAccountNotFoundException(string message)
        : base(message)
    {
    }

    public BankAccountNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}