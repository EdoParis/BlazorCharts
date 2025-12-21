using BlazorCharts.Structures;

namespace BlazorCharts.Models
{
    public class ChartAxis
    {
        private Interval range;
        private bool is_default;

        public string Title;
        public double Min { get => range.Min; }
        public double Max { get => range.Max; }
        public double Size { get => range.Size; }

        public ChartAxis(string title = null)
        {
            Title = title;
            range = default;
            is_default = true;
        }

        public void Update(double value)
        {
            if (is_default)
            {
                range = new Interval(value, value);
            }
            else
            {
                range = new Interval(Math.Min(range.Min, value), 
                                     Math.Max(range.Max, value));
            }
            is_default = false;
        }

        public void Update(Interval range)
        {
            if (is_default)
                this.range = range;
            else
            {
                range = new Interval(Math.Min(range.Min, range.Min), 
                                     Math.Max(range.Max, range.Max));
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
