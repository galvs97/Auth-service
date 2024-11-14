using System.Security.Cryptography; 
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace AuthValidator.Models 
{
    [DynamoDBTable("UserLogin")]
    public class User
    {
        [DynamoDBHashKey]
        public string IdentificationNumber { get; set; }
        [DynamoDBProperty]
        public TypeUser Type { get; set; }
        [DynamoDBProperty]
        public string Name { get; set; }
        [DynamoDBProperty]
        public string Telephone { get; set; }
        [DynamoDBProperty]
        public string Email { get; set; }
        [DynamoDBProperty]
        public DateTime BirthDate { get; set; }
    }

    public enum TypeUser 
    {
        pf,
        pj
    }
}