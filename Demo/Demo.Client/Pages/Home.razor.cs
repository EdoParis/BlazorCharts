using BlazorCharts.Models;
using BlazorCharts.Structures;

namespace DemoApp.Pages
{
    public partial class Home
    {
        private Histogram histogram;

        protected override void OnInitialized()
        {
            histogram = new Histogram("asseX", "asseY");

            for (int i=0; i<20; i++)
            {
                histogram.Add(new Bin()
                {
                    Min = i,
                    Max = i + 1,
                    Value = i * i
                });
            }
        }
    }
}
