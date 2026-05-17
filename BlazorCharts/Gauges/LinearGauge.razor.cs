using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Gauges
{
    public partial class LinearGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = 3 * PADDING;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.Axis.Size;

        private KnownColor ProgressBarColor()
        {
            foreach (Breakpoint breakpoint in Model)
            {
                if (breakpoint.Value >= Model.Value)
                    return breakpoint.Color;
            }
            return Model.Color;
        }
    }
}
