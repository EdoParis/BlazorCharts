using BlazorCharts.Models;
using BlazorCharts.Structures;

namespace DemoApp.Pages
{
    public partial class Home
    {
        private Histogram histogram;
        private Bargram bargram;

        protected override void OnInitialized()
        {
            histogram = new Histogram("asseX", "asseY");
            bargram = new Bargram("asse-1", "asse-2");

            for (int i=0; i<22; i++)
            {
                histogram.Add(new Bin()
                {
                    Min = i,
                    Max = i + 1,
                    Value = i * i
                });

                bargram.Add(new Bar()
                {
                    Label = $"{i + 1}",
                    Value = 10 + i
                });
            }
        }
    }
}
