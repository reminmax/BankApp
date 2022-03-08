using System;
using BankApp.Services.SampleDataService;
using Microcharts;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions.Navigation;
using SkiaSharp;

namespace BankApp.ViewModels.Regions
{
    public class ChartRegionViewModel : BindableBase, IRegionAware
    {
        private ISampleDataService _sampleDataService;

        public ChartRegionViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;

            ChartData = new LineChart()
            {
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = 30,
                BackgroundColor = SKColor.Parse("#FFFFFF"),
                IsAnimated = true,
                AnimationDuration = new TimeSpan(0, 0, 1),
                LineSize = 4,
                LineMode = LineMode.Straight
            };
        }

        private string _cardId { get; set; }
        public Chart ChartData { get; private set; }

        public void OnNavigatedTo(INavigationContext navigationContext)
        {
            _cardId = navigationContext.Parameters.GetValue<string>("cardId");
            InitChartData();
        }

        public bool IsNavigationTarget(INavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(INavigationContext navigationContext)
        {
            InitChartData();
        }

        private void InitChartData()
        {
            ChartData.Entries = _sampleDataService.GetChartData(_cardId);
        }
    }
}
