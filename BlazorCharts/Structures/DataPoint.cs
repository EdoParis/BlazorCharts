using BlazorGraphs.Interfaces;

namespace BlazorGraphs.Structures
{
    public struct DataPoint : IValidable
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
