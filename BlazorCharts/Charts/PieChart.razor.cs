using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Charts
{
    public partial class PieChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Piegram Model { get; set; }
        [Parameter] public EventCallback<Slice> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;

        private string SlicePath(Slice slice, double rotation = 0)
        {
            double radius = (Math.Min(width, height) - 2 * padding) / 2;
            double theta = 2 * Math.PI * slice.Value / Model.Total;
            bool is_wide = theta > Math.PI;

            return $"M {width / 2} {height / 2} " + 
                   $"L {(int)(width / 2 + radius * Math.Sin(rotation))} {(int)(height / 2 - radius * Math.Cos(rotation))} " +
                   $"A {(int)radius} {(int)radius} 0 {(is_wide ? 1 : 0)} 1 {(int)(width / 2 + radius * Math.Sin(theta + rotation))} {(int)(height / 2 - radius * Math.Cos(theta + rotation))} " +
                   "Z";
        }

        private Point SliceMidPoint(Slice slice, double rotation = 0)
        {
            double radius = (Math.Min(width, height) - 2 * padding) / 4;
            double theta = Math.PI * slice.Value / Model.Total;

            return new Point()
            {
                X = (int)(width / 2 + radius * Math.Sin(theta + rotation)),
                Y = (int)(height / 2 - radius * Math.Cos(theta + rotation))
            };
        }

        private Point SliceExternalPoint(Slice slice, double rotation = 0)
        {
            double radius = 1.1 * (Math.Min(width, height) - 2 * padding) / 2;
            double theta = Math.PI * slice.Value / Model.Total;

            return new Point()
            {
                X = (int)(width / 2 + radius * Math.Sin(theta + rotation)),
                Y = (int)(height / 2 - radius * Math.Cos(theta + rotation))
            };
        }
    }
}
