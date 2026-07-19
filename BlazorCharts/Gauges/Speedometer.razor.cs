using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Gauges
{
    public partial class Speedometer
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int radius = VIEW / 6;
        private int padding = PADDING;
        AxisLayout AxisLayout;

        protected override void OnInitialized()
        {
            AxisLayout = AxisLayout.CircularLayout()
                                   .WithRadius(2 * radius)
                                   .At(new Point(width / 2, height / 2))
                                   .From(-45)
                                   .To(225)
                                   .WithTickSize(20)
                                   .FullExternal();
        }

        private string ArcPath(double radius, double start, double end)
        {
            int startpoint_x = (int)Math.Round(width / 2 - radius * Math.Cos(start));
            int startpoint_y = (int)Math.Round(height / 2 - radius * Math.Sin(start));
            int endpoint_x = (int)Math.Round(width / 2 - radius * Math.Cos(end));
            int endpoint_y = (int)Math.Round(height / 2 - radius * Math.Sin(end));

            return $"M {startpoint_x} {startpoint_y} " +
                   $"A {radius} {radius} 0 {(end - start > Math.PI ? 1 : 0)} 1 {endpoint_x} {endpoint_y}";
        }

        private string BarPath(double degree)
        {
            double bar_width = padding / 5;
            double bar_height = 2.2 * radius;

            Point P1 = new Point()
            {
                X = (int)(width / 2 - (radius + bar_height / 2) * Math.Cos(degree) - bar_width / 2 * Math.Sin(degree)),
                Y = (int)(height / 2 - (radius + bar_height / 2) * Math.Sin(degree) + bar_width / 2 * Math.Cos(degree))
            };
            Point P2 = new Point()
            {
                X = (int)(width / 2 - (radius + bar_height / 2) * Math.Cos(degree) + bar_width / 2 * Math.Sin(degree)),
                Y = (int)(height / 2 - (radius + bar_height / 2) * Math.Sin(degree) - bar_width / 2 * Math.Cos(degree))
            };
            Point P3 = new Point()
            {
                X = (int)(width / 2 - (radius - bar_height / 2) * Math.Cos(degree) + bar_width / 2 * Math.Sin(degree)),
                Y = (int)(height / 2 - (radius - bar_height / 2) * Math.Sin(degree) - bar_width / 2 * Math.Cos(degree))
            };
            Point P4 = new Point()
            {
                X = (int)(width / 2 - (radius - bar_height / 2) * Math.Cos(degree) - bar_width / 2 * Math.Sin(degree)),
                Y = (int)(height / 2 - (radius - bar_height / 2) * Math.Sin(degree) + bar_width / 2 * Math.Cos(degree))
            };

            return $"M {P1.X} {P1.Y}" +
                   $"L {P2.X} {P2.Y}" +
                   $"L {P3.X} {P3.Y}" +
                   $"L {P4.X} {P4.Y}Z";
        }
    }
}
