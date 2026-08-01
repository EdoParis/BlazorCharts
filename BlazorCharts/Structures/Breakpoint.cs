using BlazorGraphs.Interfaces;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Breakpoint : IValidable
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public Color Color { get; set; }

        public bool IsValid()
        {
            return !double.IsInfinity(Value) &&
                   !double.IsNaN(Value);
        }
    }
}
