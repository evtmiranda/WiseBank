namespace WiseBank.Src.Services.Dtos;

public record TransferDto(int TargetBankAccountId, decimal Amount);