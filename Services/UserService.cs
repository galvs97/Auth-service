using AuthValidator.Services.Interfaces;
using AuthValidator.Models;
using AuthValidator.DbContext;

namespace AuthValidator.Services 
{
    public class UserService : IUserService 
    {
        private readonly IDynamoDBContext<User> _dynamoDbContext;

        public UserService(IDynamoDBContext<User> dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task Create(User user)
        {
            await _dynamoDbContext.SaveAsync(user);
        }

        public async Task<User> Get(string userId)
        {
            return await _dynamoDbContext.GetAsync(userId);
        }
    }
}