using Amazon;
using Amazon.DynamoDBv2;
using AuthValidator.Services.Interfaces;
using AuthValidator.Services;
using AuthValidator.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IAmazonDynamoDB>(sp => new AmazonDynamoDBClient(RegionEndpoint.USEast1));
builder.Services.AddScoped(typeof(IDynamoDBContext<>), typeof(DynamoDBContext<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "AuthValidator API", Version = "v1" });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthTokenService, AuthTokenService>();
builder.Services.AddScoped<ISmsAuthService, SmsAuthService>();
builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthValidator API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();