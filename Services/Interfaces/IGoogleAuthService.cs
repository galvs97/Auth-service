using AuthValidator.Models;
using System.Threading.Tasks;

namespace AuthValidator.Services.Interfaces
{
    public interface IGoogleAuthService 
    {
        /// <summary>
        /// Gera o código QR para autenticação de dois fatores.
        /// </summary>
        /// <param name="user">O usuário para o qual o código QR será gerado.</param>
        /// <returns>URL do código QR gerado.</returns>
        Task<string> GenerateQRCode(User user);

        /// <summary>
        /// Valida o código PIN fornecido para o usuário.
        /// </summary>
        /// <param name="user">O usuário para o qual o código PIN será validado.</param>
        /// <param name="code">O código PIN a ser validado.</param>
        /// <returns>Retorna true se o código PIN for válido, caso contrário false.</returns>
        Task<bool> ValidatePIN(string identificationNumber, string code);
    }
}