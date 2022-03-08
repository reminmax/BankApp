using BankApp.Services.SampleDataService;
using BankApp.ViewModels;
using BankApp.ViewModels.Regions;
using BankApp.Views;
using BankApp.Views.Regions;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

[assembly: ExportFont("FontAwesomeLight.ttf", Alias = "FontAwesomeLight")]
[assembly: ExportFont("FontAwesomeRegular.ttf", Alias = "FontAwesomeRegular")]
[assembly: ExportFont("FontAwesomeSolid.ttf", Alias = "FontAwesomeSolid")]
[assembly: ExportFont("GraphieLight.otf", Alias = "GraphieLight")]
[assembly: ExportFont("GraphieRegular.otf", Alias = "GraphieRegular")]
[assembly: ExportFont("GraphieSemiBold.otf", Alias = "GraphieSemiBold")]
[assembly: ExportFont("Norwester.otf", Alias = "Norwester")]

namespace BankApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterRegionServices();

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<ISampleDataService, SampleDataService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterForRegionNavigation<NotificationsRegion, NotificationsRegionViewModel>();
            containerRegistry.RegisterForRegionNavigation<ChartRegion, ChartRegionViewModel>();
            containerRegistry.RegisterForRegionNavigation<TransactionsRegion, TransactionsRegionViewModel>();
            
        }
    }
}
