using System.Drawing;

namespace BlazorCharts.Structures
{
    public struct Line
    {
        public string Label;
        public KnownColor Color;
        public Interval RangeX { get; private set; }
        public Interval RangeY { get; private set; }
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
            RangeX = new Interval(points?.Select(p => p.X));
            RangeY = new Interval(points?.Select(p => p.Y));
        }
    }
}
