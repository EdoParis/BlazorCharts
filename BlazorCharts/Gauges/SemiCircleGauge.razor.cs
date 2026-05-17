using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Gauges
{
    public partial class SemiCircleGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW / 2 + PADDING;
        private int radius = VIEW / 2 - 2 * PADDING;
        private int padding = PADDING;

        private KnownColor ProgressBarColor()
        {
            foreach (Breakpoint breakpoint in Model)
            {
                if (breakpoint.Value > Model.Value)
                    return breakpoint.Color;
            }
            return Model.Color;
        }

        private string ArcPath(double radius, double start, double end)
        {
            int startpoint_x = (int)(width / 2 - radius * Math.Cos(start));
            int startpoint_y = (int)(height - padding - radius * Math.Sin(start));
            int endpoint_x = (int)(width / 2 - radius * Math.Cos(end));
            int endpoint_y = (int)(height - padding - radius * Math.Sin(end));

            return $"M {startpoint_x} {startpoint_y} " +
                   $"A {radius} {radius} 0 0 1 {endpoint_x} {endpoint_y}";
        }
    }
}
