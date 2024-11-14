# AuthValidator API

## Visão Geral
Este projeto é uma API para autenticação, permitindo gerar tokens através do Google Authenticator ou receber SMS usando a biblioteca Twilio.

## Pacotes Utilizados
A API utiliza os seguintes pacotes NuGet:

- [AWSSDK.Core](https://www.nuget.org/packages/AWSSDK.Core) - `3.7.400.48`
- [AWSSDK.DynamoDBv2](https://www.nuget.org/packages/AWSSDK.DynamoDBv2) - `3.7.402.12`
- [FluentValidation.AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore) - `11.3.0`
- [GoogleAuthenticator](https://www.nuget.org/packages/GoogleAuthenticator) - `3.2.0`
- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) - `8.0.10`
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore) - `6.6.2`
- [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration) - `6.0.0`
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json) - `6.0.0`
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) - `6.0.0`
- [Twilio](https://www.nuget.org/packages/Twilio) - `7.6.0`

## Configuração do Twilio
Para utilizar o Twilio, você precisa criar uma conta no console deles. Consulte a documentação oficial [aqui](https://www.twilio.com/docs).

### Configuração das Credenciais
Após criar a conta no Twilio, configure as credenciais no arquivo `appsettings.json` ou salve como variáveis de ambiente:

#### No arquivo `appsettings.json`
```json
{
  "Twilio": {
    "AccountSid": "TWILIO_ACCOUNT_SID",
    "AuthToken": "TWILIO_AUTH_TOKEN",
    "From": "TWILIO_AUTH_FROM_NUMBER"
  }
}
