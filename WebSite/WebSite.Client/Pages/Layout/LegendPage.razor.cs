using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages.Layout
{
    public partial class LegendPage : ComponentBase
    {
        private Circulargram model;
        private IColorStream palette;
        private Random random;

        protected override void OnInitialized()
        {
            random = new Random();
            palette = Palettes.Primary;
            model = new Circulargram();
            model.Add(new Slice("S1", 5, palette.Next()));
            model.Add(new Slice("S2", 30, palette.Next()));
            model.Add(new Slice("S3", 5, palette.Next()));
            model.Add(new Slice("S4", 40, palette.Next()));
            model.Add(new Slice("S5", 15, palette.Next()));
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
                Color = palette.Next()
            });
        }
    }
}
