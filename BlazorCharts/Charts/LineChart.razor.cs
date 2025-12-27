using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System;
using System.Text;

namespace BlazorGraphs.Charts
{
    public partial class LineChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Linegram Model { get; set; }
        [Parameter] public Boolean ShowPoints { get; set; }
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
                    builder.Append($"M {ViewX(point.X)} {ViewY(point.Y)} ");
                    starting_point = false;
                }
                else
                {
                    builder.Append($"L {ViewX(point.X)} {ViewY(point.Y)} ");
                }
            }
            return builder.ToString();
        }

        private int ViewX(double valueX)
        {
            return (int)(padding + (width - 2 * padding) * (valueX - Model.AxisX.Min) / Model.AxisX.Size);
        }

        private int ViewY(double valueY)
        {
            return (int)(height - padding - (height - 2 * padding) * (valueY - Model.AxisY.Min) / Model.AxisY.Size);
        }
    }
}
