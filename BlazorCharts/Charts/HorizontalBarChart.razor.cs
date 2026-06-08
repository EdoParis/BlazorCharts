using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
{
    public partial class HorizontalBarChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.ValAxis.Size;
        private double scaleV => (height - 2 * padding) / Model.BinAxis.Size;

        private string BinPath(Bin bin)
        {
            return $"M {offsetH} {padding + (int)((bin.Min - Model.BinAxis.Min) * scaleV)}" +
                   $"h {(int)((bin.Value - Model.ValAxis.Min) * scaleH)} " +
                   $"v {(int)((bin.Max - bin.Min) * scaleV)} " +
                   $"h {-(int)((bin.Value - Model.ValAxis.Min) * scaleH)} " +
                   $"v {(int)((bin.Min - bin.Max) * scaleV)} " +
                   $"Z";
        }
    }
}
