using BillReminder.Api.Configuration;
using BillReminder.Api.Job;
using BillReminder.Infra.Context;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabaseContext(builder.Configuration)
    .AddInfrastructureAndServices(builder.Configuration)
    .AddPresentation()
    .AddAuthenticationAndAuthorization()
    .ConfigureHangfire(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BillReminderContext>();

    //EnsureDeleted() is an additional option that first deletes an existing database.
    dbContext.Database.EnsureCreated();

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
ExecuteHangfire();

app.Run();

void ExecuteHangfire()
{
    HangfireRecurringJob.StartBillIsDueTodayNotificationJob();
    HangfireRecurringJob.StartBillIsDueNotificationNotificationJob();
    HangfireRecurringJob.StartBillWasDueNotificationJob();
    HangfireRecurringJob.StartBillRecurrencyJob();
}
