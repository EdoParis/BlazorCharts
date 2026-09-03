using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageScatterChart : ComponentBase
    {
        private Cartesiangram model;
        private Random random;
        private Color line_color;

        protected override void OnInitialized()
        {
            random = new Random();
            line_color = Color.MediumOrchid;
            model = new Cartesiangram("AxisX", "AxisY");
            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            List<Datapoint> points4 = new();

            for (int i = 0; i <= 10; i++)
            {
                points1.Add(new Datapoint() { X = 10 * random.NextDouble(), Y = 10 * random.NextDouble() });
                points2.Add(new Datapoint() { X = 5 + 10 * random.NextDouble(), Y = 5 + 10 * random.NextDouble() });
                points3.Add(new Datapoint() { X = 10 + 10 * random.NextDouble(), Y = 10 + 10 * random.NextDouble() });
                points4.Add(new Datapoint() { X = 25 + 10 * random.NextDouble(), Y = 25 + 10 * random.NextDouble() });
            }

            model.AddSerie("Fn-1", Color.LimeGreen, points1);
            model.AddSerie("Fn-2", Color.OrangeRed, points2);
            model.AddSerie("Fn-3", Color.CadetBlue, points3);
            model.AddSerie("Fn-4", Color.DodgerBlue, points4);
        }

        private void OnChartClear()
        {
            model?.Clear();
        }

        private void OnSeriesAdd()
        {
            if (model is null)
                return;

            List<Datapoint> points = new();
            int n_points = (int)(10 + 10 * random.NextDouble());
            int offset_x = (int)(50 * random.NextDouble());
            int offset_y = (int)(50 * random.NextDouble());

            for (int i = 0; i < n_points; i++)
            {
                points.Add(new Datapoint() 
                { 
                    X = offset_x + 10 * random.NextDouble(), 
                    Y = offset_y + 10 * random.NextDouble() 
                });
            }
            model.AddSerie($"Fn-{model.SeriesCount + 1}", line_color, points);

            line_color = Color.FromArgb((int)(50 + 200 * random.NextDouble()),
                                        (int)(50 + 200 * random.NextDouble()),
                                        (int)(50 + 200 * random.NextDouble()));
        }
    }
}
