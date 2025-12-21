using BlazorCharts.Models;
using BlazorCharts.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System;
using System.Text;

namespace BlazorCharts.Charts
{
    public partial class LineChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Linegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;

        private string LinePath(Line line)
        {
            StringBuilder builder = new StringBuilder();
            bool starting_point = true;

            foreach(PointF point in line.Points)
            {
                if (starting_point)
                {
                    builder.Append($"M {(int)(padding + (width - 2 * padding) * (point.X - Model.AxisX.Min) / Model.AxisX.Size)} {(int)(height - padding - (height - 2 * padding) * (point.Y - Model.AxisY.Min) / Model.AxisY.Size)} ");
                    starting_point = false;
                }
                else
                {
                    builder.Append($"L {(int)(padding + (width - 2 * padding) * (point.X - Model.AxisX.Min) / Model.AxisX.Size)} {(int)(height - padding - (height - 2 * padding) * (point.Y - Model.AxisY.Min) / Model.AxisY.Size)} ");
                }
            }
            return builder.ToString();
        }
    }
}
