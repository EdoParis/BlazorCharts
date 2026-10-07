using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages.Layout
{
    public partial class LegendPage : ComponentBase
    {
        private Circulargram model;
        private IColorStream palette;

        protected override void OnInitialized()
        {
            palette = new RandomPalette(10);
            model = new Circulargram();

            for (int i = 0; i < 5; i++)
            {
                OnSliceAdd();
            }
        }

        private void OnChartClear()
        {
            model?.Clear();
        }

        private void OnSliceAdd()
        {
            Color next_color = palette.Next();
            model.Add(new Slice()
            {
                Label = $"S{model.SlicesCount + 1}",
                Value = Math.Round(255 * next_color.GetBrightness()),
                Color = next_color
            });
        }
    }
}
