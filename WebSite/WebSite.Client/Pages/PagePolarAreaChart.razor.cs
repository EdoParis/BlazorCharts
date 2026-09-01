using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PagePolarAreaChart : ComponentBase
    {
        private Circulargram model;
        private Random random;
        private Color slice_color;

        protected override void OnInitialized()
        {
            random = new Random();
            model = new Circulargram();
            model.Add(new Slice("S1", 5, Color.Purple));
            model.Add(new Slice("S2", 30, Color.OrangeRed));
            model.Add(new Slice("S3", 5, Color.Gold));
            model.Add(new Slice("S4", 40, Color.Aqua));
            model.Add(new Slice("S5", 15, Color.DodgerBlue));
            slice_color = Color.MediumOrchid;
        }

        private void OnChartClear()
        {
            model?.Clear();
        }

        private void OnSliceAdd()
        {
            model.Add(new Slice()
            {
                Label = $"S{model.SlicesCount + 1}",
                Value = Math.Round(90 * random.NextDouble() + 10),
                Color = slice_color
            });
            slice_color = Color.FromArgb((int)(50 + 200 * random.NextDouble()),
                                         (int)(50 + 200 * random.NextDouble()),
                                         (int)(50 + 200 * random.NextDouble()));
        }

        private void OnSliceClick(Slice slice)
        {
            Console.WriteLine($"Clicked slice {slice.Label} with value {slice.Value}");
        }
    }
}
