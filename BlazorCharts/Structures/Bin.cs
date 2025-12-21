namespace BlazorCharts.Structures
{
    public struct Bin
    {
        public double Min;
        public double Max;
        public double Value;

        public Bin(double min, double max, double value)
        {
            Min = min;
            Max = max;
            Value = value;
        }
    }
}
