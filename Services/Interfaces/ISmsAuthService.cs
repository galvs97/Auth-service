using AuthValidator.Models;
using System.Threading.Tasks;

namespace AuthValidator.Services.Interfaces
{
    public interface ISmsAuthService
    {
        /// <summary>
        /// Gera um token de autenticação e envia uma mensagem SMS para o usuário.
        /// </summary>
        /// <param name="user">O usuário para o qual o token será gerado e enviado.</param>
        Task GenerateTokenAsync(User user);

        /// <summary>
        /// Valida o token fornecido pelo usuário.
        /// </summary>
        /// <param name="user">O usuário para o qual o token será validado.</param>
        /// <param name="token">O token a ser validado.</param>
        /// <returns>Retorna true se o token for válido, caso contrário false.</returns>
        Task<bool> ValidateTokenAsync(string identificationNumber, string token);
    }
}