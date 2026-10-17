using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs
{
    public struct BubbleEventArgs
    {
        public String Serie { get; set; }
        public Color Color { get; set; }
        public Bubblepoint Bubble { get; set; }

        internal BubbleEventArgs(Serie serie, Bubblepoint bubble)
        {
            Serie = serie.Label;
            Color = serie.Color;
            Bubble = bubble;
        }
    }
}
