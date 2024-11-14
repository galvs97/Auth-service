using System;
using Amazon.DynamoDBv2.DataModel;

namespace AuthValidator.Models.Utils
{
    public class SMSNotification
    {
        [DynamoDBProperty]
        public string From { get; set; }
        [DynamoDBProperty]
        public string To { get; set; }
        [DynamoDBProperty]
        public string Message { get; set; }
    }
}