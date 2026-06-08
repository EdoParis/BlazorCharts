using BlazorGraphs.Enums;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
{
    public partial class BarChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] [Obsolete("use HorizontalBarChart component instead")] public Positioning Direction { get; set; }
        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private int originH => Model is null ? offsetH : offsetH - (int)(Model.BinAxis.Min * scaleH);
        private int originV => Model is null ? offsetV : offsetV + (int)(Model.ValAxis.Min * scaleV);
        private double scaleH => (width - 2 * padding) / Model.BinAxis.Size;
        private double scaleV => (height - 2 * padding) / Model.ValAxis.Size;

        private string BinPath(Bin bin)
        {
            return $"M {offsetH + (int)((bin.Min - Model.BinAxis.Min) * scaleH)} {originV}" +
                   $"v {-(int)(bin.Value * scaleV)} " +
                   $"h {(int)((bin.Max - bin.Min) * scaleH)} " +
                   $"v {(int)(bin.Value * scaleV)} " +
                   $"h {(int)((bin.Min - bin.Max) * scaleH)} " +
                   $"Z";
        }
    }
}
