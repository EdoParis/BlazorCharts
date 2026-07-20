using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public struct Line : IValidable
    {
        public string Label { get; set; }
        public KnownColor Color { get; set; }
        public IEnumerable<PointD> Points { get; private set; }

        public Line()
        {
            Label = null;
            Color = KnownColor.Black;
            Points = Array.Empty<PointD>();
        }

        public Line(string label, KnownColor color, IEnumerable<PointD> points)
        {
            Label = label;
            Color = color;
            Points = points ?? Array.Empty<PointD>();
        }

        public bool IsValid()
        {
            return Points != null; 
        }
    }
}
