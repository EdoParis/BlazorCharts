using BlazorGraphs.Core;

namespace BlazorGraphs
{
    public struct Bar : IValidable
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public Bar(string label, double value)
        {
            Label = label;
            Value = value;
        }

        public bool IsValid()
        {
            return !double.IsInfinity(Value) &&
                   !double.IsNaN(Value);
        }
    }
}
