using BlazorCharts.Models;
using BlazorCharts.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System;

namespace BlazorCharts.Charts
{
    public partial class BarChart
    {
        private const int VIEW = 500;
        private const int PADDING = 50;

        [Parameter] public KnownColor Color { get; set; }
        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;

        private string BinPath(Bin bin)
        {
            return $"M {(int)(padding + (width - 2 * padding) * (bin.Min - Model.AxisX.Min) / Model.AxisX.Range)} {height - padding} " + 
                   $"v {(int)((-height + 2 * padding) * (bin.Value - Model.AxisY.Min) / Model.AxisY.Range)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Max - bin.Min) / Model.AxisX.Range)} " +
                   $"v {(int)((height - 2 * padding) * (bin.Value - Model.AxisY.Min) / Model.AxisY.Range)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Min - bin.Max) / Model.AxisX.Range)} " +
                   $"Z";
        }
    }
}
