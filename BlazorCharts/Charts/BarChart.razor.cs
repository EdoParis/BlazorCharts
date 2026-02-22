using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System;
using BlazorGraphs.Enums;

namespace BlazorGraphs.Charts
{
    public partial class BarChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public KnownColor Color { get; set; }
        [Parameter] public Positioning Direction { get; set; }
        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;

        private string VerticalBinPath(Bin bin)
        {
            return $"M {(int)(padding + (width - 2 * padding) * (bin.Min - Model.BinAxis.Min) / Model.BinAxis.Size)} {height - padding} " +
                   $"v {(int)((-height + 2 * padding) * (bin.Value - Model.ValAxis.Min) / Model.ValAxis.Size)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Max - bin.Min) / Model.BinAxis.Size)} " +
                   $"v {(int)((height - 2 * padding) * (bin.Value - Model.ValAxis.Min) / Model.ValAxis.Size)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Min - bin.Max) / Model.BinAxis.Size)} " +
                   $"Z";
        }

        private string HorizontalBinPath(Bin bin)
        {
            return $"M {padding} {(int)(padding + (height - 2 * padding) * (bin.Min - Model.BinAxis.Min) / Model.BinAxis.Size)} " +
                   $"h {(int)((width - 2 * padding) * (bin.Value - Model.ValAxis.Min) / Model.ValAxis.Size)} " +
                   $"v {(int)((height - 2 * padding) * (bin.Max - bin.Min) / Model.BinAxis.Size)} " +
                   $"h {(int)((-width + 2 * padding) * (bin.Value - Model.ValAxis.Min) / Model.ValAxis.Size)} " +
                   $"v {(int)((height - 2 * padding) * (bin.Min - bin.Max) / Model.BinAxis.Size)} " +
                   $"Z";
        }
    }
}
