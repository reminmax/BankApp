using System;
using System.Collections.ObjectModel;
using BankApp.Models;
using BankApp.Services.SampleDataService;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions.Navigation;

namespace BankApp.ViewModels.Regions
{
    public class TransactionsRegionViewModel : BindableBase, IRegionAware
    {
        private ISampleDataService _sampleDataService;

        public TransactionsRegionViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
            TransactionsList = new ObservableCollection<TransactionModel>();
        }

        private string _cardId { get; set; }
        public ObservableCollection<TransactionModel> TransactionsList { get; private set; }

        public void OnNavigatedTo(INavigationContext navigationContext)
        {
            _cardId = navigationContext.Parameters.GetValue<string>("cardId");
            InitForm();
        }

        public bool IsNavigationTarget(INavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(INavigationContext navigationContext)
        {
            _cardId = navigationContext.Parameters.GetValue<string>("cardId");
            InitForm();
        }

        private void InitForm()
        {
            if (_cardId is not null)
            {
                TransactionsList.Clear();

                var items = _sampleDataService.GetTransactionsList(_cardId);
                foreach (var item in items)
                {
                    TransactionsList.Add(item);
                }
            }
        }
    }
}
