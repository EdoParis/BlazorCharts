using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs
{
    public struct PointEventArgs
    {
        public String Serie { get; set; }
        public Color Color { get; set; }
        public Datapoint Point { get; set; }

        internal PointEventArgs(Serie serie, Datapoint point)
        {
            Serie = serie.Label;
            Color = serie.Color;
            Point = point;
        }
    }
}
