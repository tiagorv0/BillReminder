using BillReminder.Application.Service.BillService;
using BillReminder.Application.Service.NotificationService;
using Hangfire;

namespace BillReminder.Api.Job;

public static class HangfireRecurringJob
{
    public static void StartBillIsDueTodayNotificationJob()
    {
        RecurringJob.AddOrUpdate<INotificationService>("BillIsDueTodayNotificationJob", x => x.BillIsDueTodayNotificationAsync(), Cron.Daily( 8, 0));
    }

    public static void StartBillIsDueNotificationNotificationJob()
    {
        RecurringJob.AddOrUpdate<INotificationService>("BillIsDueNotificationJob", x => x.BillIsDueNotificationAsync(), Cron.Daily(8, 0));
    }

    public static void StartBillWasDueNotificationJob()
    {
        RecurringJob.AddOrUpdate<INotificationService>("BillWasDueNotificationJob", x => x.BillWasDueNotificationAsync(), Cron.Daily(8, 0));
    }

    public static void StartBillRecurrencyJob()
    {
        RecurringJob.AddOrUpdate<IBillService>("BillRecurrencyJob", x => x.CreateBillRecurrencyAsync(), Cron.Monthly());
    }
}
