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

        public LegendItem(Line line)
        {
            Color = line.Color;
            Text = line.Label;
        }

        public LegendItem(Threshold threshold)
        {
            Color = threshold.Color;
            Text = string.IsNullOrWhiteSpace(threshold.Label) ? $"{threshold.From.ToString("0.##")} - {threshold.To.ToString("0.##")}" : threshold.Label;
        }
    }
}
