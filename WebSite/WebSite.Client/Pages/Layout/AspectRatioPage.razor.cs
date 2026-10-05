using BlazorGraphs;
using Microsoft.AspNetCore.Components;

namespace WebApp.Pages.Layout
{
    public partial class AspectRatioPage : ComponentBase
    {
        private Bubblegram bubble_model;
        private double aspectratio;

        protected override void OnInitialized()
        {
            Random random = new Random();
            IColorStream palette = Palettes.Primary;
            aspectratio = AspectRatios.Square;

            bubble_model = new Bubblegram("Axis-X", "Axis-Y");
            for (int s = 1; s <= 5; s++)
            {
                List<Bubblepoint> bubbles = new();
                for (int i = 0; i <= 5; i++)
                {
                    bubbles.Add(new Bubblepoint() { X = 10 * (s + random.NextDouble()), Y = 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
                }
                bubble_model.AddSerie($"Fn-{s}", palette.Next(), bubbles);
            }
        }

        private void OnRatioChange(ChangeEventArgs e)
        {
            if (e?.Value is null)
                return;

            if (double.TryParse(e.Value.ToString(), out double value))
            {
                aspectratio = value / 10;
            }
        }
    }
}
