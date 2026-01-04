using BlazorGraphs.Internal;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Line
    {
        public string Label;
        public KnownColor Color;
        internal Span RangeX { get; private set; }
        internal Span RangeY { get; private set; }
        public IEnumerable<PointF> Points { get; private set; }

        public Line()
        {
            Label = null;
            Color = KnownColor.Black;
            Points = Array.Empty<PointF>();
        }

        public Line(string label, KnownColor color, IEnumerable<PointF> points)
        {
            Label = label;
            Color = color;
            Points = points ?? Array.Empty<PointF>();
            RangeX = new Span(points?.Select(p => p.X));
            RangeY = new Span(points?.Select(p => p.Y));
        }

        public Line(string label, KnownColor color, IEnumerable<Point> points)
        {
            Label = label;
            Color = color;
            Points = points?.Select(p => new PointF(p.X, p.Y)) ?? Array.Empty<PointF>();
            RangeX = new Span(points?.Select(p => p.X));
            RangeY = new Span(points?.Select(p => p.Y));
        }
    }
}
