using BlazorGraphs.Core;

namespace BlazorGraphs
{
    public struct Datapoint : IValidable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public bool IsValid()
        {
            return !double.IsNaN(X) &&
                   !double.IsNaN(Y) &&
                   !double.IsInfinity(X) &&
                   !double.IsInfinity(Y);
        }
    }
}
