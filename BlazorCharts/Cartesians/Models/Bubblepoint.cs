using BlazorGraphs.Core;

namespace BlazorGraphs
{
    public struct Bubblepoint : IValidable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Value { get; set; }
        public double Radius { get => Math.Sqrt(Value); }

        public bool IsValid()
        {
            return Value >= 0 &&
                   !double.IsNaN(X) &&
                   !double.IsNaN(Y) &&
                   !double.IsNaN(Value) &&
                   !double.IsInfinity(X) &&
                   !double.IsInfinity(Y) &&
                   !double.IsInfinity(Value);
        }
    }
}
