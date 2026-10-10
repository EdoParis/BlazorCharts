using System.Drawing;

namespace BlazorGraphs
{
    public struct LegendItem
    {
        public Color Color { get; set; }
        public string Text { get; set; }

        public LegendItem() { }

        public LegendItem(Slice slice)
        {
            Color = slice.Color;
            Text = string.IsNullOrWhiteSpace(slice.Label) ? "-" : slice.Label;
        }

        public LegendItem(Breakpoint threshold)
        {
            Color = threshold.Color;
            Text = string.IsNullOrWhiteSpace(threshold.Label) ? $"< {threshold.Value.ToString("0.##")}" : threshold.Label;
        }
    }
}
