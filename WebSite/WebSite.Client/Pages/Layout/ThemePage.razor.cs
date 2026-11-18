using BlazorGraphs;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace WebApp.Pages.Layout
{
    public partial class ThemePage : ComponentBase
    {
        private Histogram histogram;
        private Theme theme;

        protected override void OnInitialized()
        {
            Random random = new Random();
            double amplitude = Math.Round(50 * (2 * random.NextDouble() - 1));
            histogram = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue, Color.Orange);

            for (int i = 0; i < 15; i++)
            {
                histogram.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = Math.Round(10 + amplitude * Math.Cos(histogram.BinsCount / 2d))
                });
            }
        }
    }
}
