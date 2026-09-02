using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageSpeedometer : ComponentBase
    {
        Random random;
        Double last_threshold;
        Boolean inner_axis;
        Gaugegram model1;

        protected override void OnInitialized()
        {
            random = new Random();
            model1 = new Gaugegram(0, 1000, null, Color.RoyalBlue);
            model1.Value = 800;
        }

        private void OnGaugeClear()
        {
            model1?.Clear();
            last_threshold = default;
        }

        private void OnColorChanged(ChangeEventArgs e)
        {
            if (model1 is null)
                return;

            model1.Color = ColorTranslator.FromHtml(e?.Value?.ToString());
        }

        private void OnValueChanged(ChangeEventArgs e)
        {
            if (model1 is null)
                return;

            if (double.TryParse(e?.Value?.ToString(), out double new_value))
            {
                model1.Value = new_value;
            }
        }

        private void OnBreakPointAdd()
        {
            if (model1 is null)
                return;

            if (last_threshold >= 1000)
                return;

            last_threshold += Math.Round(100 + 250 * random.NextDouble());

            if (last_threshold > 1000)
                last_threshold = 1000;

            model1.AddBreakpoint(new Breakpoint()
            {
                Label = $"Level-{last_threshold}",
                Value = last_threshold,
                Color = Color.FromArgb((int)(50 + 200 * random.NextDouble()),
                                       (int)(50 + 200 * random.NextDouble()),
                                       (int)(50 + 200 * random.NextDouble()))
            });
        }
    }
}
