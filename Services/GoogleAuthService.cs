using System;
using AuthValidator.Services.Interfaces;
using AuthValidator.Models;
using AuthValidator.Models.Utils;
using Google.Authenticator;
using System.Text.Json;

namespace AuthValidator.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IAuthTokenService _service;
        private readonly TwoFactorAuthenticator _tfa;
        public GoogleAuthService(IAuthTokenService service)
        {
            _service = service;
            _tfa = new TwoFactorAuthenticator();
        }

        public async Task<string> GenerateQRCode(User user)
        {
            try
            {
                string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                SetupCode setupInfo = _tfa.GenerateSetupCode("auth", "authValidator", user.IdentificationNumber, false, 3);

                AuthToken auth = new AuthToken()
                {
                    Key = user.IdentificationNumber,
                    Token = key,
                    SentAt = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddMinutes(5),
                    googleAuth = new GoogleAuth() { QrCode = setupInfo.QrCodeSetupImageUrl }
                };

                await _service.SaveTokenAsync(auth, user);

                string qrCode = setupInfo.QrCodeSetupImageUrl;

                return qrCode;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> ValidatePIN(string identificationNumber, string code)
        {
            try
            {
                return await _service.ValidateTokenAsync(identificationNumber, code) || _tfa.ValidateTwoFactorPIN(identificationNumber, code);
            }
            catch
            {
                throw;
            }
        }
    }
}