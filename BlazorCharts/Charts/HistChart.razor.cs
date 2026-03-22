using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System;

namespace BlazorGraphs.Charts
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
        private int offsetH => padding;
        private int offsetV => height - padding;
        private int originH => offsetH - (int)(Model.AxisX.Min * scaleH);
        private int originV => offsetV + (int)(Model.AxisY.Min * scaleV);
        private double scaleH => (width - 2 * padding) / Model.AxisX.Size;
        private double scaleV => (height - 2 * padding) / Model.AxisY.Size;

        private string BinPath(Bin bin)
        {
            return $"M {offsetH + (int)((bin.Min - Model.AxisX.Min) * scaleH)} {originV} " + 
                   $"v {-(int)(bin.Value * scaleV)} " +
                   $"h {(int)((bin.Max - bin.Min) * scaleH)} " +
                   $"v {(int)(bin.Value * scaleV)} " +
                   $"h {(int)((bin.Min - bin.Max) * scaleH)} " +
                   $"Z";
        }
    }
}
