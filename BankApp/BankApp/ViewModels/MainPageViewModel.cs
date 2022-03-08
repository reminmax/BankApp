using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BankApp.Models;
using BankApp.Services.SampleDataService;
using BankApp.Views.Regions;
using Prism.Navigation;
using Prism.Regions;
using Xamarin.Forms;

namespace BankApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private decimal _balance;
        private BankCardModel _bankCardsListCurrentItem;
        private string _region;
        private ISampleDataService _sampleDataService;
        private BankCardModel _selectedBankCard;

        public MainPageViewModel(INavigationService navigationService, 
            ISampleDataService sampleDataService,
            IRegionManager regionManager) : base(navigationService)
        {
            _regionManager = regionManager;
            _sampleDataService = sampleDataService;

            ChangeRegionCommand = new Command<string>(ChangeRegionCommandHandler);
            Region = "transactions";

            LoadBankCardsList();
            UpdateBalance();
        }

        public ObservableCollection<BankCardModel> BankCardsList { get; private set; }
        private IRegionManager _regionManager { get; }

        public ICommand ChangeRegionCommand { get; set; }

        public BankCardModel BankCardsListCurrentItem
        {
            get => _bankCardsListCurrentItem;
            set
            {
                SetProperty(ref _bankCardsListCurrentItem, value);

                InitializeRegions(Region);
            }
        }

        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        public decimal Balance
        {
            get => _balance;
            set => SetProperty(ref _balance, value);
        }

        public BankCardModel SelectedBankCard
        {
            get => _selectedBankCard;
            set => SetProperty(ref _selectedBankCard, value);
        }

        private void InitializeRegions(string region)
        {
            var param = new NavigationParameters()
            {
                { "cardId", BankCardsListCurrentItem?.Id }
            };

            switch (region)
            {
                case "notifications":
                    _regionManager.RequestNavigate("NotificationsRegion", nameof(NotificationsRegion), param);
                    break;
                case "transactions":
                    _regionManager.RequestNavigate("TransactionsRegion", nameof(TransactionsRegion), param);
                    break;
                case "chart":
                    _regionManager.RequestNavigate("ChartRegion", nameof(ChartRegion), param);
                    break;
                default:
                    _regionManager.RequestNavigate("TransactionsRegion", nameof(TransactionsRegion), param);
                    _regionManager.RequestNavigate("ChartRegion", nameof(ChartRegion), param);
                    _regionManager.RequestNavigate("NotificationsRegion", nameof(NotificationsRegion), param);
                    break;
            }
        }

        public override void Initialize(INavigationParameters parameters)
        {
            InitializeRegions(string.Empty);
        }

        private void ChangeRegionCommandHandler(string region)
        {
            Region = region;
            InitializeRegions(region);
        }

        private void LoadBankCardsList()
        {
            BankCardsList = new ObservableCollection<BankCardModel>(_sampleDataService.GetBankCardsList());

            BankCardsListCurrentItem = BankCardsList.FirstOrDefault();
        }

        private void UpdateBalance()
        {
            Balance = _sampleDataService.GetTotalBalance();
        }
    }
}
