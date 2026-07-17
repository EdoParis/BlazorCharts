namespace BlazorGraphs.Internal
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

        public Interval(IEnumerable<int> values)
        {
            Min = values.FirstOrDefault();
            Max = values.FirstOrDefault();

            foreach (double val in values)
            {
                if (val < Min)
                    Min = val;

                if (val > Max)
                    Max = val;
            }
            Size = Max - Min;
        }

        public Interval(IEnumerable<double> values)
        {
            Min = values.FirstOrDefault();
            Max = values.FirstOrDefault();

            foreach (double val in values)
            {
                if (val < Min)
                    Min = val;

                if (val > Max)
                    Max = val;
            }
            Size = Max - Min;
        }

        public Interval(IEnumerable<float> values)
        {
            Min = values.FirstOrDefault();
            Max = values.FirstOrDefault();

            foreach (double val in values)
            {
                if (val < Min)
                    Min = val;

                if (val > Max)
                    Max = val;
            }
            Size = Max - Min;
        }

        public bool Contains(double value)
        {
            return value >= Min && value <= Max;
        }

        public bool Overlap(Interval other)
        {
            return other.Min < this.Max && 
                   other.Max > this.Min;
        }
    }
}
