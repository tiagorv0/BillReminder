using BillReminder.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabaseContext(builder.Configuration)
    .AddInfrastructureAndServices(builder.Configuration)
    .AddPresentation()
    .AddAuthenticationAndAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
