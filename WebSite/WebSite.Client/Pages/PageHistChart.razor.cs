using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageHistChart : ComponentBase
    {
        private Histogram model1;
        private Histogram model2;
        private Histogram model3;

        protected override void OnInitialized()
        {
            model1 = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue);
            model2 = new Histogram("Axis-X", "Axis-Y", Color.LimeGreen, Color.Orange);
            model3 = new Histogram("Axis-X", "Axis-Y", Color.OrangeRed);

            for (int i = 0; i < 10; i++)
            {
                model1.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = 30 - Math.Pow(i - 4, 2)
                });

                model2.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = 10 - Math.Pow(i - 4, 2)
                });

                model3.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = -Math.Pow(i - 4, 2)
                });
            }
        }

        private void OnBinClick(Bin bin)
        {
            Console.WriteLine($"Clicked bin with value: {bin.Value}");
        }
    }
}
