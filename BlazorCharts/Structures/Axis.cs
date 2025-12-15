namespace BlazorCharts.Structures
{
    public struct Axis
    {
        public int Step;
        public double Min;
        public double Max;
        public double Range;
        private bool IsDefault;

        public Axis()
        {
            IsDefault = true;
            Range = default;
            Step = default;
            Min = default;
            Max = default;
        }

        public Axis Update(double value)
        {
            if (IsDefault)
            {
                return new Axis()
                {
                    Min = value,
                    Max = value,
                    Range = Max - Min,
                    IsDefault = false
                };
            }
            else
            {
                return new Axis()
                {
                    Min = Math.Min(Min, value),
                    Max = Math.Max(Max, value),
                    Range = Math.Max(Max, value) - Math.Min(Min, value),
                    IsDefault = false
                };
            }
        }

        public IEnumerable<double> Ticks()
        {
            List<double> ticks = new List<double>();

            if (Max != Min)
            {
                int step = (int)((Max - Min) / 5);

                if (step > 5)
                    step = step - step % 5;

                if (step <= 0)
                    step = 1;

                for (double t = Min; t < Max; t += step)
                {
                    for (int i = 1; i < 6; i++)
                    {
                        double tick = t + i * step / 5d;

                        if (tick <= Max)
                            ticks.Add(t + i * step / 5d);
                        else
                            break;
                    }
                }
            }
            return ticks;
        }
    }
}
