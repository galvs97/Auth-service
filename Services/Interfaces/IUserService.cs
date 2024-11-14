using System.Threading.Tasks;
using AuthValidator.Models;

namespace AuthValidator.Services.Interfaces
{
    public interface IUserService 
    {
        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">O usuário a ser criado.</param>
        Task Create(User user);

        /// <summary>
        /// Recupera um usuário com base no ID fornecido. (CPF/CNPJ)
        /// </summary>
        /// <param name="userId">O ID do usuário a ser recuperado.</param>
        /// <returns>O usuário recuperado.</returns>
        Task<User> Get(string userId);
    }
}