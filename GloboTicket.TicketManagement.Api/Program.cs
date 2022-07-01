using GlobolTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastuctureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "GloboTicket Ticket Management API",
        });

        //c.OperationFilter<FileResultContentTypeOperationFilter>();
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseCors("Open");

app.MapControllers();

app.Run();
