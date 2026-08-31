using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageHistChart : ComponentBase
    {
        private Histogram model1;
        private Random random;
        private Double offset;

        protected override void OnInitialized()
        {
            random = new Random();
            offset = Math.Round(50 * (2 * random.NextDouble() - 1));
            model1 = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue, Color.Orange);

            for (int i = 0; i < 10; i++)
            {
                model1.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = Math.Round(offset * Math.Cos(model1.BinsCount / 2d))
                });
            }
        }

        private void OnChartClear()
        {
            model1?.Clear();
            offset = Math.Round(50 * (2 * random.NextDouble() - 1));
        }

        private void OnBinAdd()
        {
            if (model1 is null)
                return;

            model1.Add(new Bin()
            {
                Min = 2 * model1.BinsCount,
                Max = 2 * model1.BinsCount + 2,
                Value = Math.Round(offset * Math.Cos(model1.BinsCount / 2d))
            });
        }

        private void OnBinClick(Bin bin)
        {
            Console.WriteLine($"Clicked bin with value: {bin.Value}");
        }
    }
}
