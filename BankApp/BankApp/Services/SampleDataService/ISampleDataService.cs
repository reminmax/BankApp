using System.Collections.Generic;
using BankApp.Models;
using Microcharts;

namespace BankApp.Services.SampleDataService
{
    public interface ISampleDataService
    {
        List<BankCardModel> GetBankCardsList();

        decimal GetTotalBalance();

        List<TransactionModel> GetTransactionsList(string cardId);

        List<NotificationModel> GetNotificationsList(string cardId);

        ChartEntry[] GetChartData(string cardId);
    }
}
