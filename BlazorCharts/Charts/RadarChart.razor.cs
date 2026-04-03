using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Text;

namespace BlazorGraphs.Charts
{
    public partial class RadarChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public KnownColor Color { get; set; }
        [Parameter] public Radargram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;

        private string Path()
        {
            int i = 0;
            StringBuilder str_builder = new();

            foreach(Rating rating in Model)
            {
                double r = rating.Value / Model.AxisR.Size * (Math.Min(width, height) - 2 * padding) / 2;
                double x = width / 2 + r * Math.Sin(2 * Math.PI / Model.Categories * i);
                double y = height / 2 - r * Math.Cos(2 * Math.PI / Model.Categories * i);

                str_builder.Append(i == 0 ? $"M {(int)x} {(int)y} " : $"L {(int)x} {(int)y} ");
                i++;
            }
            str_builder.Append("Z");
            return str_builder.ToString();
        }

        private string Path(double radius)
        {
            int i = 0;
            StringBuilder str_builder = new();

            foreach (Rating rating in Model)
            {
                double r = radius / Model.AxisR.Size * (Math.Min(width, height) - 2 * padding) / 2;
                double x = width / 2 + r * Math.Sin(2 * Math.PI / Model.Categories * i);
                double y = height / 2 - r * Math.Cos(2 * Math.PI / Model.Categories * i);

                str_builder.Append(i == 0 ? $"M {(int)x} {(int)y} " : $"L {(int)x} {(int)y} ");
                i++;
            }
            str_builder.Append("Z");
            return str_builder.ToString();
        }
    }
}
