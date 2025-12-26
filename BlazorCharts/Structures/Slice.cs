using System.Drawing;

namespace BlazorCharts.Structures
{
    public struct Slice
    {
        public string Label { get; private set; }
        public double Value { get; private set; }
        public KnownColor Color { get; private set; }

        public Slice(string label, double value, KnownColor color)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);

            Label = label;
            Value = value;
            Color = color;
        }
    }
}
