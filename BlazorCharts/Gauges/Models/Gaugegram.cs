using System.Drawing;
using System.Collections;
using BlazorGraphs.Core;

namespace BlazorGraphs
{
    public class Gaugegram : IEnumerable<Breakpoint>, ILegend
    {
        private List<Breakpoint> breakpoints;
        internal NumericAxis Axis { get; private set; }
        public Color Color { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }
        public bool HasBreakPoints { get => breakpoints?.Count > 0; }

        public Gaugegram(double min, double max, string title, Color color)
        {
            Axis = new NumericAxis(new Interval(min, max));
            breakpoints = new List<Breakpoint>();
            Color = color;
            Value = min;
            Title = title;
        }

        public void AddBreakpoint(Breakpoint breakpoint)
        {
            ExceptionUtils.ThrowIfInvalid(breakpoint);
            ArgumentOutOfRangeException.ThrowIfLessThan(breakpoint.Value, Axis.Min);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(breakpoint.Value, Axis.Max);

            for (int i = 0; i < breakpoints.Count; i++)
            {
                if (breakpoints[i].Value == breakpoint.Value)
                    throw new ArgumentException($"breakpoint already present with value: {breakpoint.Value}");

                if (breakpoints[i].Value > breakpoint.Value)
                {
                    breakpoints.Insert(i, breakpoint);
                    return;
                }
            }
            breakpoints.Add(breakpoint);
        }

        public void Clear()
        {
            breakpoints.Clear();
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            if (breakpoints.Any())
            {
                return breakpoints.Select(t => new LegendItem(t));
            }
            else
            {
                return [new LegendItem()
                {
                    Color = Color,
                    Text = Title
                }];
            }
        }

        public IEnumerator<Breakpoint> GetEnumerator()
        {
            return breakpoints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
