using BlazorCharts.Models;
using BlazorCharts.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System;

namespace BlazorCharts.Charts
{
    public partial class HistChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public KnownColor Color { get; set; }
        [Parameter] public Histogram Model { get; set; }
        [Parameter] public EventCallback<Bin> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;

        private string BinPath(Bin bin)
        {
            return $"M {(int)(padding + (width - 2 * padding) * (bin.Min - Model.AxisX.Min) / Model.AxisX.Size)} {height - padding} " + 
                   $"v {(int)((-height + 2 * padding) * (bin.Value - Model.AxisY.Min) / Model.AxisY.Size)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Max - bin.Min) / Model.AxisX.Size)} " +
                   $"v {(int)((height - 2 * padding) * (bin.Value - Model.AxisY.Min) / Model.AxisY.Size)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Min - bin.Max) / Model.AxisX.Size)} " +
                   $"Z";
        }
    }
}
