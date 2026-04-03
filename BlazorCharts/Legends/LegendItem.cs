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
    }
}
