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

            Min = Math.Floor(min);
            Max = Math.Ceiling(max);
            Size = Max - Min;
        }

        public static Interval From(IEnumerable<double> values)
        {
            double? min = null;
            double? max = null;

            foreach (double val in values)
            {
                if (!min.HasValue || val < min)
                    min = val;

                if (!max.HasValue || val > max)
                    max = val;
            }

            if (!min.HasValue || !max.HasValue)
            {
                return new Interval();
            }
            else if (min == max)
            {
                return new Interval(min.Value - 1, max.Value + 1);
            }
            else
            {
                return new Interval(min.Value, max.Value);
            }
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
