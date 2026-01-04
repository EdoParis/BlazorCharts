namespace BlazorGraphs.Internal
{
    internal struct Span
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Size { get; private set; }

        public Span(double min, double max)
        {
            if (min > max)
                throw new ArgumentException();

            Min = min;
            Max = max;
            Size = Max - Min;
        }

        public Span(IEnumerable<int> values)
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

        public Span(IEnumerable<double> values)
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

        public Span(IEnumerable<float> values)
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
