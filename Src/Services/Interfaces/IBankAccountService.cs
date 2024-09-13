using WiseBank.Src.Entities;
using WiseBank.Src.Services.Dtos;

namespace WiseBank.Src.Services.Interfaces;

public interface IBankAccountService
{
    /// <summary>
    /// Cria uma conta bancária de acordo com os dados informados
    /// </summary>
    /// <param name="createBankAccountDto">Dados para criação da conta</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>A conta bancária criada</returns>
    Task<BankAccount> CreateAsync(CreateBankAccountDto createBankAccountDto, CancellationToken cancellationToken);

    /// <summary>
    /// Obtém uma conta bancária pelo identificador fornecido
    /// </summary>
    /// <param name="bankAccountId">Identificador único da conta bancária</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Uma instância de <see cref="BankAccount"/> correspondente ao identificador fornecido</returns>
    /// <exception cref="BankAccountNotFoundException">Lançada quando a conta bancária com o identificador fornecido não é encontrada</exception>
    Task<BankAccount> GetByIdAsync(int bankAccountId, CancellationToken cancellationToken);

    /// <summary>
    /// Realiza um depósito em uma conta bancária
    /// </summary>
    /// <param name="bankAccountId">Identificador único da conta bancária</param>
    /// <param name="depositDto">Valor a ser depositado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>A instância atualizada da conta bancária após o depósito</returns>
    /// <exception cref="BankAccountNotFoundException">Lançada quando a conta bancária com o identificador fornecido não é encontrada</exception>
    Task<BankAccount> DepositAsync(int bankAccountId, DepositDto depositDto, CancellationToken cancellationToken);

    /// <summary>
    /// Realiza um saque em uma conta bancária
    /// </summary>
    /// <param name="bankAccountId">Identificador único da conta bancária</param>
    /// <param name="depositDto">Valor a ser sacado</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>A instância atualizada da conta bancária após o saque</returns>
    /// <exception cref="BankAccountNotFoundException">Lançada quando a conta bancária com o identificador fornecido não é encontrada</exception>
    Task<BankAccount> WithdrawAsync(int bankAccountId, WithdrawDto withdrawDto, CancellationToken cancellationToken);

    /// <summary>
    /// Realiza uma transferência entre duas contas bancárias
    /// </summary>
    /// <param name="bankAccountId">Identificador único da conta bancária</param>
    /// <param name="transferDto">Dados da transferência, incluindo o identificador da conta de destino e o valor a ser transferido</param>
    /// <param name="cancellationToken">Token de cancelamento para interromper a operação, se necessário</param>
    /// <returns>A instância da conta bancária de origem após a transferência</returns>
    /// <exception cref="BankAccountNotFoundException">Lançada quando a conta bancária de origem ou destino não é encontrada</exception>
    Task<BankAccount> TransferAsync(int bankAccountId, TransferDto transferDto, CancellationToken cancellationToken);
}