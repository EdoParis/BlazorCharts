using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;
using System.Text;

namespace BlazorGraphs.Charts
{
    public partial class LineChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Linegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.AxisX.Size;
        private double scaleV => (height - 2 * padding) / Model.AxisY.Size;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;

        protected override void OnInitialized()
        {
            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .From(padding)
                                    .To(width - padding)
                                    .At(height - padding);

            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .From(height - padding)
                                    .To(padding)
                                    .At(padding);
        }

        private string LinePath(Line line)
        {
            StringBuilder builder = new StringBuilder();
            bool starting_point = true;

            foreach(PointF point in line.Points)
            {
                builder.Append($"{(starting_point ? "M" : "L")} {offsetH + (int)((point.X - Model.AxisX.Min) * scaleH)} {offsetV - (int)((point.Y - Model.AxisY.Min) * scaleV)} ");
                starting_point = false;
            }
            return builder.ToString();
        }
    }
}
