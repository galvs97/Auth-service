using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthValidator.Services.Interfaces;
using AuthValidator.Models;
using AuthValidator.Models.Utils;
using AuthValidator.DbContext;

namespace AuthValidator.Services
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly IDynamoDBContext<AuthToken> _dynamoDbContext;

        public AuthTokenService(IDynamoDBContext<AuthToken> dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task SaveTokenAsync(AuthToken auth, User user)
        {
            await _dynamoDbContext.SaveAsync(auth);
        }

        public async Task<bool> ValidateTokenAsync(string identificationNumber, string token)
        {
            var result = await _dynamoDbContext.GetAsync(identificationNumber);

            if (result == null || !string.IsNullOrEmpty(result.Token) || (result.Token != token && result.smsNotification is not null) || result.ExpirationDate <= DateTime.Now)
            {
                return false;
            }

            return true;
        }

        public async Task<AuthToken> Get(User user)
        {
            return await _dynamoDbContext.GetAsync(user.IdentificationNumber);
        }
    }
}