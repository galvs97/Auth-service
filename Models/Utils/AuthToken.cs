using System;
using Amazon.DynamoDBv2.DataModel;

namespace AuthValidator.Models.Utils 
{
    [DynamoDBTable("AuthToken")]
    public class AuthToken 
    {
        [DynamoDBHashKey]
        public string Key { get; set; }
        [DynamoDBProperty]
        public string Token { get; set; }
        [DynamoDBProperty]
        public DateTime ExpirationDate { get; set; }
        [DynamoDBProperty]
        public DateTime? SentAt { get; set; }

        public GoogleAuth? googleAuth { get; set; }
        public SMSNotification? smsNotification { get; set; }
    }
}