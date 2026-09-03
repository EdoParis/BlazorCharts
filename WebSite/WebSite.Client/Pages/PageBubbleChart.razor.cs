using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageBubbleChart : ComponentBase
    {
        private Bubblegram model;
        private Random random;
        private Color serie_color;

        protected override void OnInitialized()
        {
            random = new Random();
            serie_color = Color.MediumOrchid;
            model = new Bubblegram("AxisX", "AxisY");
            List<Bubblepoint> bubbles1 = new();
            List<Bubblepoint> bubbles2 = new();
            List<Bubblepoint> bubbles3 = new();
            List<Bubblepoint> bubbles4 = new();

            for (int i = 0; i <= 5; i++)
            {
                bubbles1.Add(new Bubblepoint() { X = 10 * random.NextDouble(), Y = 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
                bubbles2.Add(new Bubblepoint() { X = 5 + 10 * random.NextDouble(), Y = 5 + 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
                bubbles3.Add(new Bubblepoint() { X = 10 + 10 * random.NextDouble(), Y = 10 + 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
                bubbles4.Add(new Bubblepoint() { X = 25 + 10 * random.NextDouble(), Y = 25 + 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
            }

            model.AddSerie("Fn-1", Color.LimeGreen, bubbles1);
            model.AddSerie("Fn-2", Color.OrangeRed, bubbles2);
            model.AddSerie("Fn-3", Color.CadetBlue, bubbles3);
            model.AddSerie("Fn-4", Color.DodgerBlue, bubbles4);
        }

        private void OnChartClear()
        {
            model?.Clear();
        }

        private void OnSeriesAdd()
        {
            if (model is null)
                return;

            List<Bubblepoint> bubbles = new();
            int n_points = (int)(1 + 5 * random.NextDouble());
            int offset_x = (int)(50 * random.NextDouble() - 25);
            int offset_y = (int)(50 * random.NextDouble() - 25);

            for (int i = 0; i < n_points; i++)
            {
                bubbles.Add(new Bubblepoint()
                {
                    X = offset_x + 10 * random.NextDouble(),
                    Y = offset_y + 10 * random.NextDouble(),
                    Value = 10 * random.NextDouble()
                });
            }
            model.AddSerie($"Fn-{model.SeriesCount + 1}", serie_color, bubbles);

            serie_color = Color.FromArgb((int)(50 + 200 * random.NextDouble()),
                                         (int)(50 + 200 * random.NextDouble()),
                                         (int)(50 + 200 * random.NextDouble()));
        }
    }
}
