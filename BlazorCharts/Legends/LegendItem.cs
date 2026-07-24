using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using System.Drawing;

namespace BlazorGraphs.Legends
{
    public struct LegendItem
    {
        public KnownColor Color { get; set; }
        public string Text { get; set; }

        public LegendItem() { }

        public LegendItem(Slice slice)
        {
            Color = slice.Color;
            Text = slice.Label;
        }

        public LegendItem(Breakpoint threshold)
        {
            Color = threshold.Color;
            Text = string.IsNullOrWhiteSpace(threshold.Label) ? $"< {threshold.Value.ToString("0.##")}" : threshold.Label;
        }
    }
}
