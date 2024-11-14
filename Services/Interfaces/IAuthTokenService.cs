using AuthValidator.Models;
using AuthValidator.Models.Utils;
using System.Threading.Tasks;

namespace AuthValidator.Services.Interfaces
{
    public interface IAuthTokenService
    {
        /// <summary>
        /// Salva o token de autenticação para o usuário.
        /// </summary>
        /// <param name="auth">O token de autenticação a ser salvo.</param>
        /// <param name="user">O usuário associado ao token.</param>
        Task SaveTokenAsync(AuthToken auth, User user);

        /// <summary>
        /// Valida se o token fornecido é válido para o usuário.
        /// </summary>
        /// <param name="user">O usuário para o qual o token será validado.</param>
        /// <param name="token">O token a ser validado.</param>
        /// <returns>Retorna true se o token for válido, caso contrário false.</returns>
        Task<bool> ValidateTokenAsync(string identificationNumber, string token);

        /// <summary>
        /// Recupera o token de autenticação do usuário.
        /// </summary>
        /// <param name="user">O usuário para o qual o token será recuperado.</param>
        /// <returns>O token de autenticação do usuário.</returns>
        Task<AuthToken> Get(User user);
    }
}