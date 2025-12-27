namespace BlazorGraphs.Internal
{
    internal class Axis
    {
        private Span range;
        private bool is_default;

        public string Title;
        public double Min { get => range.Min; }
        public double Max { get => range.Max; }
        public double Size { get => range.Size; }

        public Axis(string title = null)
        {
            Title = title;
            range = default;
            is_default = true;
        }

        public void Update(double value)
        {
            if (is_default)
            {
                range = new Span(value, value);
            }
            else
            {
                range = new Span(Math.Min(range.Min, value), 
                                     Math.Max(range.Max, value));
            }
            is_default = false;
        }

        public void Update(Span r)
        {
            if (is_default)
                range = r;
            else
            {
                range = new Span(Math.Min(range.Min, r.Min), 
                                     Math.Max(range.Max, r.Max));
            }
            is_default = false;
        }

        public IEnumerable<double> Ticks()
        {
            List<double> ticks = new List<double>();

            if (Max != Min)
            {
                int step = (int)(Size / 5);

                if (step > 5)
                    step = step - step % 5;

                if (step <= 0)
                    step = 1;

                for (double t = Min - Min % 5; t < Max; t += step)
                {
                    for (int i = 1; i < 6; i++)
                    {
                        double tick = (int)(t + i * step / 5);

                        if (tick <= Max)
                            ticks.Add(tick);
                        else
                            break;
                    }
                }
            }
            return ticks;
        }
    }
}
