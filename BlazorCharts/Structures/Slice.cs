using BlazorGraphs.Interfaces;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Slice : IValidable
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public KnownColor Color { get; set; }

        public Slice(double value, KnownColor color)
        {
            Value = value;
            Color = color;
        }

        public Slice(string label, double value, KnownColor color)
        {
            Label = label;
            Value = value;
            Color = color;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Label) && 
                   !double.IsInfinity(Value) &&
                   !double.IsNaN(Value) &&
                   Value > 0;
        }
    }
}
