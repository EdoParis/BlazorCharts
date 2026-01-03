using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Slice
    {
        public string Label { get; private set; }
        public double Value { get; private set; }
        public KnownColor Color { get; private set; }

        public Slice(double value, KnownColor color)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);

            Value = value;
            Color = color;
        }

        public Slice(string label, double value, KnownColor color)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);

            Label = label;
            Value = value;
            Color = color;
        }
    }
}
