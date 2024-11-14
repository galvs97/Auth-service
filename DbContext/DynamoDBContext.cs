using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthValidator.DbContext 
{
    public class DynamoDBContext<T> : IDynamoDBContext<T> where T : class
    {
        private readonly IAmazonDynamoDB _dynamoDBClient; 
        private readonly DynamoDBContext _context;
        public DynamoDBContext(IAmazonDynamoDB dynamoDBClient) 
        { 
            _dynamoDBClient = dynamoDBClient; 
            _context = new DynamoDBContext(dynamoDBClient);
        }

        public async Task SaveAsync(T item)
        {
            await _context.SaveAsync(item);
        }

        public async Task<T> GetAsync(string key)
        {
            return await _context.LoadAsync<T>(key);
        }

        public async Task UpdateAsync(T item)
        {
            await _context.SaveAsync(item);
        }

        public async Task DeleteAsync(string key)
        {
            await _context.DeleteAsync<T>(key);
        }

        public async Task<List<T>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<T>(conditions).GetRemainingAsync();
        }
    }
}