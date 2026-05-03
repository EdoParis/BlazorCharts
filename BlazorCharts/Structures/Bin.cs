using BlazorGraphs.Interfaces;

namespace BlazorGraphs.Structures
{
    public struct Bin : IValidable
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Value { get; set; }

        public Bin(double min, double max, double value)
        {
            Min = min;
            Max = max;
            Value = value;
        }

        public bool IsValid()
        {
            return Max > Min;
        }
    }
}
