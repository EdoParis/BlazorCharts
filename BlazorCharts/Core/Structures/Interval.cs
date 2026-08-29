namespace BlazorGraphs.Core
{
    internal struct Interval
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Size { get; private set; }

        public Interval(double min, double max)
        {
            if (double.IsInfinity(min) || double.IsInfinity(max))
                throw new ArgumentOutOfRangeException("Infinite range");

            if (double.IsNaN(min) || double.IsNaN(max))
                throw new ArgumentOutOfRangeException("Invalid range");

            if (min > max)
                throw new ArgumentOutOfRangeException("min must be lower or equal than max");

            Min = min;
            Max = max;
            Size = Max - Min;
        }

        public static Interval From(IEnumerable<double> values)
        {
            double min = values.FirstOrDefault();
            double max = values.FirstOrDefault();

            foreach (double val in values)
            {
                if (val < min)
                    min = val;

                if (val > max)
                    max = val;
            }

            if (min == max)
            {
                min -= 1;
                max += 1;
            }
            return new Interval(min, max);
        }

        public bool Contains(double value)
        {
            return value >= Min && value <= Max;
        }

        public bool Overlap(Interval other)
        {
            return other.Min < Max && 
                   other.Max > Min;
        }
    }
}
