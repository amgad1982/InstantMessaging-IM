using FastEndpoints;
using FastEndpoints.Swagger;
using InstantMessaging_IM.Application.Common.Behaviours.Global;
using InstantMessaging_IM.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddFastEndpoints().AddSwaggerDocument();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = ep =>
    {
        ep.PreProcessor<LoggingBehaviour>(Order.Before);
        ep.PreProcessor<PrePerformanceBehaviour>(Order.Before);
        ep.PostProcessor<PostPerformanceBehaviour>(Order.After);
    };
}).UseSwaggerGen();

app.Run();