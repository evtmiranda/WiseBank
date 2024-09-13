namespace WiseBank.Src.Services.Dtos;

public record TransferDto(int SourceBankAccountId, int TargetBankAccountId, decimal Amount);