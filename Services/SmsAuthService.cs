using System;
using AuthValidator.Services.Interfaces;
using AuthValidator.Models;
using AuthValidator.Models.Utils;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace AuthValidator.Services
{
    public class SmsAuthService : ISmsAuthService
    {
        private readonly IConfiguration _config;
        private readonly IAuthTokenService _service;
        public SmsAuthService(IConfiguration config, IAuthTokenService service)
        {
            _config = config;
            _service = service;
            TwilioClient.Init(_config["TwilioAuth:AccountSid"], _config["TwilioAuth:AuthToken"]);
        }

        public async Task GenerateTokenAsync(User user)
        {
            try
            {
                var expirationDate = DateTime.Now.AddMinutes(5);
                string token = GenerateToken(6);
                string body = $"Seu código de autenticação é: {token}. O token expira em {expirationDate:dd/MM/yyyy HH:mm:ss}";

                var message = await MessageResource.CreateAsync(
                    body: body,
                    from: new PhoneNumber(_config["TwilioAuth:From"]),
                    to: new PhoneNumber(user.Telephone)
                );

                AuthToken auth = new AuthToken()
                {
                    Key = user.IdentificationNumber,
                    Token = token,
                    SentAt = DateTime.Now,
                    ExpirationDate = expirationDate,
                    smsNotification = new SMSNotification()
                    {
                        From = _config["TwilioAuth:From"],
                        To = user.Telephone,
                        Message = body
                    }
                };

                await _service.SaveTokenAsync(auth, user);
            }
            catch
            {
                throw;
            }
        }

        private string GenerateToken(int length)
        {
            Random random = new Random(); 
            string digits = string.Empty; 

            for (int i = 0; i < length; i++) 
            { 
                digits += random.Next(0, 10).ToString(); 
            }
            return digits;
        }

        public async Task<bool> ValidateTokenAsync(string identificationNumber, string token)
        {
            return await _service.ValidateTokenAsync(identificationNumber, token);
        }
    }
}