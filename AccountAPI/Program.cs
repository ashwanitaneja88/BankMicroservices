using AccountAPI;
using Consul;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddServiceDiscovery(o=>o.UseConsul());
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

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

app.UseAuthorization();

app.MapControllers();


app.Run();


