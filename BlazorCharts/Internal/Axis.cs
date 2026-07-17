namespace BlazorGraphs.Internal
{
    internal class Axis
    {
        private Span range;
        private int multiple;
        private bool is_default;

        public string Title;
        public double Min { get => range.Min; }
        public double Max { get => range.Max; }
        public double Size { get => range.Size; }

        public Axis(string title = null)
        {
            Title = title;
            range = default;
            multiple = 5;
            is_default = true;
        }

        public Axis(Span interval, string title = null) : this(title)
        {
            range = interval;
            is_default = false;
        }

        public bool Contains(double value)
        {
            return range.Contains(value);
        }

        public void Update(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentOutOfRangeException(nameof(value));

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

        [Obsolete]
        public IEnumerable<double> Ticks(int multiple)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(multiple, 0);
            List<double> ticks = new List<double>();

            if (Max != Min)
            {
                int step = (int)(Size / multiple);

                if (step % multiple > multiple / 2)
                    step = step - step % multiple + multiple;
                else
                    step = step - step % multiple;

                if (step <= 0)
                    step = 1;

                for (double t = Min - Min % multiple; t <= Max; t += step)
                {
                    double? last_tick = null;

                    for (int i = 0; i < multiple; i++)
                    {
                        double tick = (int)(t + i * step / multiple);

                        if (tick != last_tick && range.Contains(tick))
                        {
                            ticks.Add(tick);
                            last_tick = tick;
                        }
                    }
                }
            }
            return ticks;
        }

        public IEnumerable<Tick> Ticks(AxisLayout layout)
        {
            ArgumentNullException.ThrowIfNull(layout);
            List<Tick> ticks = new List<Tick>();

            if (Max != Min)
            {
                int step = (int)(Size / multiple);

                if (step % multiple > multiple / 2)
                    step = step - step % multiple + multiple;
                else
                    step = step - step % multiple;

                if (step <= 0)
                    step = 1;

                for (double t = Min - Min % multiple; t <= Max; t += step)
                {
                    double? last_tick = null;

                    for (int i = 0; i < multiple; i++)
                    {
                        double tick_value = t + i * step / multiple;
                        int tick_position = layout.StartingPoint + (int)((tick_value - Min) / Size * (layout.EndingPoint - layout.StartingPoint));

                        if (tick_value != last_tick && range.Contains(tick_value))
                        {
                            ticks.Add(new Tick()
                            {
                                Position = tick_position,
                                IsMaster = i == 0,
                                Label = i == 0 ? tick_value.ToString("0.###") : null
                            });
                            last_tick = tick_value;
                        }
                    }
                }
            }
            return ticks;
        }
    }
}
