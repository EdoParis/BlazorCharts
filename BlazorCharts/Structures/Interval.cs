namespace BlazorCharts.Structures
{
    public struct Interval
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Size { get; private set; }

        public Interval(double min, double max)
        {
            if (min > max)
                throw new ArgumentException();

            Min = min;
            Max = max;
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
    }
}
