using BlazorGraphs.Interfaces;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Slice : IValidable
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public Color Color { get; set; }

        public Slice(double value, Color color)
        {
            Value = value;
            Color = color;
        }

        public Slice(string label, double value, Color color)
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
