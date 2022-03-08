using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BankApp.Models;
using Microcharts;
using SkiaSharp;

namespace BankApp.Services.SampleDataService
{
    public class SampleDataService : ISampleDataService
    {
        public decimal GetTotalBalance()
        {
            return 23600.45M;
        }

        public List<BankCardModel> GetBankCardsList()
        {
            return new List<BankCardModel>()
            {
                new BankCardModel()
                {
                    Id = "1234 2345 3456 6789",
                    BankName = "Citibank",
                    Balance = 10500.20M,
                    Expiry = "10/2023"
                },
                new BankCardModel()
                {
                    Id = "6789 1234 2345 3456",
                    BankName = "JPMorgan Chase & Co",
                    Balance = 7200.15M,
                    Expiry = "04/2024"
                },
                new BankCardModel()
                {
                    Id = "3456 6789 1234 2345",
                    BankName = "Wells Fargo & Co",
                    Balance = 5900.10M,
                    Expiry = "04/2024"
                }
            };
        }

        public List<TransactionModel> GetTransactionsList(string cardId)
        {
            if (cardId == "1234 2345 3456 6789")
            {
                return new List<TransactionModel>()
                {
                    new TransactionModel()
                    {
                        Amount = 254.78M,
                        Date = new DateTime(2021, 2, 11),
                        IsDebit = false,
                        Details = "Grocery store"
                    },
                    new TransactionModel()
                    {
                        Amount = 3600,
                        Date = new DateTime(2021, 2, 14),
                        IsDebit = true,
                        Details = "Income"
                    },
                    new TransactionModel()
                    {
                        Amount = 400,
                        Date = new DateTime(2021, 2, 20),
                        IsDebit = false,
                        Details = "Tax payment"
                    },
                    new TransactionModel()
                    {
                        Amount = 200,
                        Date = new DateTime(2021, 3, 2),
                        IsDebit = false,
                        Details = "Withdrawal"
                    },
                    new TransactionModel()
                    {
                        Amount = 200,
                        Date = new DateTime(2021, 3, 5),
                        IsDebit = false,
                        Details = "Fund transfer"
                    }
                };
            }

            if (cardId == "6789 1234 2345 3456")
            {
                return new List<TransactionModel>()
                {
                    new TransactionModel()
                    {
                        Amount = 278.24M,
                        Date = new DateTime(2021, 2, 10),
                        IsDebit = false,
                        Details = "Grocery store"
                    },
                    new TransactionModel()
                    {
                        Amount = 4200,
                        Date = new DateTime(2021, 2, 11),
                        IsDebit = true,
                        Details = "Income"
                    },
                    new TransactionModel()
                    {
                        Amount = 500,
                        Date = new DateTime(2021, 2, 12),
                        IsDebit = false,
                        Details = "Tax payment"
                    },
                    new TransactionModel()
                    {
                        Amount = 300,
                        Date = new DateTime(2021, 3, 5),
                        IsDebit = false,
                        Details = "Withdrawal"
                    },
                    new TransactionModel()
                    {
                        Amount = 350,
                        Date = new DateTime(2021, 3, 10),
                        IsDebit = false,
                        Details = "Fund transfer"
                    }
                };
            }

            if (cardId == "3456 6789 1234 2345")
            {
                return new List<TransactionModel>()
                {
                    new TransactionModel()
                    {
                        Amount = 437.91M,
                        Date = new DateTime(2021, 3, 4),
                        IsDebit = false,
                        Details = "Grocery store"
                    },
                    new TransactionModel()
                    {
                        Amount = 3800,
                        Date = new DateTime(2021, 3, 10),
                        IsDebit = true,
                        Details = "Income"
                    },
                    new TransactionModel()
                    {
                        Amount = 360,
                        Date = new DateTime(2021, 3, 14),
                        IsDebit = false,
                        Details = "Tax payment"
                    },
                    new TransactionModel()
                    {
                        Amount = 250,
                        Date = new DateTime(2021, 3, 16),
                        IsDebit = false,
                        Details = "Withdrawal"
                    },
                    new TransactionModel()
                    {
                        Amount = 410,
                        Date = new DateTime(2021, 3, 24),
                        IsDebit = false,
                        Details = "Fund transfer"
                    }
                };
            }

            return new List<TransactionModel>();
        }

        public List<NotificationModel> GetNotificationsList(string cardId)
        {
            if (cardId == "1234 2345 3456 6789")
            {
                return new List<NotificationModel>()
                {
                    new NotificationModel()
                    {
                        Date = new DateTime(2021, 6, 10),
                        Message = "Transfer received"
                    },
                    new NotificationModel()
                    {
                        Date = new DateTime(2021, 7, 14),
                        Message = "New bank card issued"
                    },
                };
            }

            if (cardId == "6789 1234 2345 3456")
            {
                return new List<NotificationModel>()
                {
                    new NotificationModel()
                    {
                        Date = new DateTime(2021, 7, 12),
                        Message = "Transfer received"
                    },
                    new NotificationModel()
                    {
                        Date = new DateTime(2021, 8, 22),
                        Message = "New bank card issued"
                    },
                };
            }

            if (cardId == "3456 6789 1234 2345")
            {
                return new List<NotificationModel>()
                {
                    new NotificationModel()
                    {
                        Date = new DateTime(2021, 4, 15),
                        Message = "Transfer received"
                    },
                    new NotificationModel()
                    {
                        Date = new DateTime(2021, 6, 18),
                        Message = "New bank card issued"
                    },
                };
            }

            return new List<NotificationModel>();
        }

        public ChartEntry[] GetChartData(string cardId)
        {
            ChartEntry[] entries = new ChartEntry[12];

            SKColor color = SKColor.Parse("#1d6efe");
            int startValue = 1500;
            string[] monthNames = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames.Take(12).ToArray();
            Random rnd = new Random();

            for (int i = 0; i < 12; i++)
            {
                int result = rnd.Next(startValue - 350, startValue + 500);
                startValue = result;

                entries[i] = new ChartEntry(result)
                {
                    Label = monthNames[i],
                    ValueLabel = result.ToString(),
                    Color = color
                };
            }

            return entries;
        }
    }
}
