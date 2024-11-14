using System;
using Amazon.DynamoDBv2.DataModel;

namespace AuthValidator.Models.Utils
{
    public class GoogleAuth
    {
        [DynamoDBProperty]
        public string QrCode { get; set; }
    }
}