using System;
using System.ComponentModel;
using Prism.Navigation;
using Prism.Regions.Navigation;
using Xamarin.CommunityToolkit.UI.Views;

namespace BankApp.ViewModels
{
    public class BaseRegionViewModel : INotifyPropertyChanged, IRegionAware
    {
        public BaseRegionViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected INavigationService _navigationService { get; set; }

        public string Title { get; set; }
        public LayoutState MainState { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnNavigatedTo(INavigationContext navigationContext) { }

        public virtual bool IsNavigationTarget(INavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNavigatedFrom(INavigationContext navigationContext) { }
    }
}
