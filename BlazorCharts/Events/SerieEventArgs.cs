using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs
{
    public struct SerieEventArgs
    {
        public String Serie { get; set; }
        public Color Color { get; set; }

        internal SerieEventArgs(Serie serie)
        {
            Serie = serie.Label;
            Color = serie.Color;
        }
    }
}
