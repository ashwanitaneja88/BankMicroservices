using APIGetawayAT;
using AuthAPI;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot().AddConsul().AddDelegatingHandler<CustomExceptionDelegatingHandler>();
builder.Services.AddJwtAuthentication();
builder.Services.AddTransient<JwtTokenService>();
// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// Register custom middleware before Ocelot
app.UseMiddleware<OcelotExceptionMiddleware>();
app.UseOcelot().Wait();

app.Run();
