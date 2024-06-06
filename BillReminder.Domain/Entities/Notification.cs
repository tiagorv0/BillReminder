using BillReminder.Domain.Entities.Common;
using System.Globalization;

namespace BillReminder.Domain.Entities;
public class Notification : EntityBase
{
    public string Title { get; private set; }
    public string Message { get; private set; }

    public Guid BillId { get; private set; }
    public Bill Bill { get; private set; }

    public Notification()
    {
        
    }

    public void BillIsDueTodayNotification(Bill bill)
    {
        BillId = bill.Id;
        Title = "Vencimento de Conta";
        Message = $"Sua conta {bill.Name} de valor R$ {bill.Value.ToString("C", CultureInfo.CurrentCulture)} vencerá hoje";
    }

    public void BillWasDueNotification(Bill bill)
    {
        BillId = bill.Id;
        Title = "Conta Atrasada";
        Message = $"Sua conta {bill.Name} de valor R$ {bill.Value.ToString("C", CultureInfo.CurrentCulture)} venceu à {bill.ExpireDate.Date.Subtract(DateTime.Today)} dias";
    }

    public void BillIsDueNotification(Bill bill)
    {
        BillId = bill.Id;
        Title = "Conta à vencer";
        Message = $"Sua conta {bill.Name} de valor R$ {bill.Value.ToString("C", CultureInfo.CurrentCulture)} está prestes à vencer";
    }
}
