using System.Collections;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Rating
    {
        public string Label { get; private set; }
        public double Value { get; private set; }

        public Rating(string label, double value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(label);
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);

            Label = label;
            Value = value;
        }
    }
}
