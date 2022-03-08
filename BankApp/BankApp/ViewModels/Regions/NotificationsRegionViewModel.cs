using System;
using System.Collections.ObjectModel;
using BankApp.Models;
using BankApp.Services.SampleDataService;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions.Navigation;

namespace BankApp.ViewModels.Regions
{
    public class NotificationsRegionViewModel : BindableBase, IRegionAware
    {
        private ISampleDataService _sampleDataService;

        public NotificationsRegionViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
            NotificationsList = new ObservableCollection<NotificationModel>();
        }

        private string _cardId { get; set; }
        public ObservableCollection<NotificationModel> NotificationsList { get; private set; }

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
                NotificationsList.Clear();

                var items = _sampleDataService.GetNotificationsList(_cardId);
                foreach (var item in items)
                {
                    NotificationsList.Add(item);
                }
            }
        }
    }
}
