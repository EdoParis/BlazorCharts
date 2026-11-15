using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages.Charts
{
    public partial class PageScatterChart : ComponentBase
    {
        private Cartesiangram model;
        private Theme theme;
        private Random random;
        private Color line_color;
        private Double aspectratio;

        protected override void OnInitialized()
        {
            random = new Random();
            aspectratio = AspectRatios.Square;
            line_color = Color.MediumVioletRed;
            model = new Cartesiangram("AxisX", "AxisY");
            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            List<Datapoint> points4 = new();
            List<Datapoint> points5 = new();

            for (int i = 0; i <= 10; i++)
            {
                points1.Add(new Datapoint() { X = 2 * i, Y = 50 + i * i });
                points2.Add(new Datapoint() { X = 2 * i, Y = (i + 2) * (i + 2) });
                points3.Add(new Datapoint() { X = 2 * i, Y = (i + 4) * (i + 4) });
                points4.Add(new Datapoint() { X = 2 * i, Y = (i + 6) * (i + 6) });
                points5.Add(new Datapoint() { X = 10 + 2 * i, Y = (i + 5) * (i + 5) });
            }

            model.AddSerie("Fn-1", Color.LimeGreen, points1);
            model.AddSerie("Fn-2", Color.OrangeRed, points2);
            model.AddSerie("Fn-3", Color.CadetBlue, points3);
            model.AddSerie("Fn-4", Color.DodgerBlue, points4);
            model.AddSerie("Fn-5", Color.MediumOrchid, points5);
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
            int offset_x = (int)(100 * random.NextDouble() - 50);
            int offset_y = (int)(100 * random.NextDouble() - 50);

            for (int i = 0; i < n_points; i++)
            {
                points.Add(new Datapoint() 
                { 
                    X = offset_x + 25 * random.NextDouble(), 
                    Y = offset_y + 25 * random.NextDouble() 
                });
            }
            model.AddSerie($"Fn-{model.SeriesCount + 1}", line_color, points);

            line_color = Color.FromArgb((int)(50 + 200 * random.NextDouble()),
                                        (int)(50 + 200 * random.NextDouble()),
                                        (int)(50 + 200 * random.NextDouble()));
        }

        private void OnPointClick(PointEventArgs args)
        {
            Console.WriteLine($"Clicked point of serie {args.Serie} with coordinates ({args.Point.X} | {args.Point.Y})");
        }
    }
}
