using BlazorGraphs.Enums;
using BlazorGraphs.Interfaces;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Line : IValidable
    {
        public string Label { get; set; }
        public DrawMode DrawMode { get; set; }
        public KnownColor Color { get; set; }
        public IEnumerable<PointF> Points { get; private set; }

        public Line()
        {
            Label = null;
            Color = KnownColor.Black;
            Points = Array.Empty<PointF>();
        }

        public Line(string label, KnownColor color, IEnumerable<PointF> points, DrawMode draw_mode = DrawMode.Drawline)
        {
            Label = label;
            Color = color;
            DrawMode = draw_mode;
            Points = points ?? Array.Empty<PointF>();
        }

        public Line(string label, KnownColor color, IEnumerable<Point> points, DrawMode draw_mode = DrawMode.Drawline)
        {
            Label = label;
            Color = color;
            DrawMode = draw_mode;
            Points = points?.Select(p => new PointF(p.X, p.Y)) ?? Array.Empty<PointF>();
        }

        public bool IsValid()
        {
            return Points != null; 
        }
    }
}
