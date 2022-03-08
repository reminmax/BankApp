namespace BankApp.Models
{
    public class ChartItemModel
    {
        public ChartItemModel(string xValue, double yValue)
        {
            Month = xValue;
            Target = yValue;
        }

        public string Month { get; set; }

        public double Target { get; set; }
    }
}
